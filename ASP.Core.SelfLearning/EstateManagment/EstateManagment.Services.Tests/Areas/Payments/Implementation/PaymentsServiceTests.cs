using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Data.Models.Enums;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Areas.Payments.Implementation;
using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;
using EstateManagment.Services.Models.Areas.Payments.Payments;
using EstateManagment.Web.Common.Mapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests.Areas.Payments.Implementation
{
    public class PaymentsServiceTests
    {
        [Fact]
        public async Task AllConsumablePaymentsAsync_ShouldReturn_AllRentsThatAreNotPaid_IfSuchExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstPayment = new Payment
            {
                Id = 1,
                PaidOn = new DateTime(2018, 12, 12),
                Amount =10,
                MonthlyPaymentConsumableId =1,
                CashPayment =false
            };
            var secndPayment = new Payment
            {
                Id = 2,
                PaidOn = new DateTime(2017, 11, 6),
                Amount = 20,
                MonthlyPaymentConsumableId = 2,
                CashPayment = true
            };
            var thirdPayment = new Payment
            {
                Id = 3,
                PaidOn = new DateTime(2016, 11, 12),
                Amount = 30,
                MonthlyPaymentConsumableId = 1,
                CashPayment = false
            };
            var forthPayment = new Payment
            {
                Id = 4,
                PaidOn = new DateTime(2015, 12, 15),
                Amount = 40,
                MonthlyPaymentConsumableId = 3,
                CashPayment = false
            };
            var fifthPayment = new Payment
            {
                Id = 5,
                PaidOn = new DateTime(2019, 12, 15),
                Amount = 50,
                MonthlyPaymentConsumableId = null,
                CashPayment = false
            };
            await db.Payments.AddRangeAsync(firstPayment, secndPayment, thirdPayment, forthPayment,fifthPayment);
            await db.SaveChangesAsync();
            var paymentService = new PaymentsService(mapper, db, null);
            //Act
            var result = await paymentService.AllConsumablePaymentsAsync();
            //Assert
            result
                .Should()
                .BeOfType<List<PaymentConsumablesListingModel>>()
                .And
                .HaveCount(4)
                .And
                .Match(x => x.ElementAt(0).Amount == 10
                    && x.ElementAt(1).Amount == 20
                    && x.ElementAt(2).CashPayment==false);
        }

        [Fact]
        public async Task AllRentPaymentsAsync_ShouldReturn_AllRentsThatAreNotPaid_IfSuchExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstPayment = new Payment
            {
                Id = 1,
                PaidOn = new DateTime(2018, 12, 12),
                Amount = 10,
                MonthlyPaymentRentId = 1,
                CashPayment = false
            };
            var secndPayment = new Payment
            {
                Id = 2,
                PaidOn = new DateTime(2017, 11, 6),
                Amount = 20,
                MonthlyPaymentRentId = 2,
                CashPayment = true
            };
            var thirdPayment = new Payment
            {
                Id = 3,
                PaidOn = new DateTime(2016, 11, 12),
                Amount = 30,
                MonthlyPaymentRentId = 1,
                CashPayment = false
            };
            var forthPayment = new Payment
            {
                Id = 4,
                PaidOn = new DateTime(2015, 12, 15),
                Amount = 40,
                MonthlyPaymentRentId = 3,
                CashPayment = false
            };
            var fifthPayment = new Payment
            {
                Id = 5,
                PaidOn = new DateTime(2019, 12, 15),
                Amount = 50,
                MonthlyPaymentRentId = null,
                CashPayment = false
            };
            await db.Payments.AddRangeAsync(firstPayment, secndPayment, thirdPayment, forthPayment, fifthPayment);
            await db.SaveChangesAsync();
            var paymentService = new PaymentsService(mapper, db, null);
            //Act
            var result = await paymentService.AllRentPaymentsAsync();
            //Assert
            result
                .Should()
                .BeOfType<List<PaymentRentListingModel>>()
                .And
                .HaveCount(4)
                .And
                .Match(x => x.ElementAt(0).Amount == 10
                    && x.ElementAt(1).Amount == 20
                    && x.ElementAt(2).CashPayment == false);
        }

        [Fact]
        public async Task FilterConsumablesAsync_ShouldReturn_CorrectQueryResult_DependingOnInput()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthConsumable =  new MonthlyPaymentConsumable
            {
                Id = 1,
                RentAgreement = new RentAgreement
                {
                    Id = 1,
                    ClientId = 1
                }
            };
            var secondMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                RentAgreement = new RentAgreement
                {
                    Id = 1,
                    ClientId = 1
                }
            };
            var thirdMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 3,
                RentAgreement = new RentAgreement
                {
                    Id = 2,
                    ClientId = 2
                }
            };
            var forthMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 4,
                RentAgreement = new RentAgreement
                {
                    Id = 1,
                    ClientId = 1
                }
            };
            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthConsumable, secondMonthConsumable, thirdMonthConsumable, forthMonthConsumable);

            var firstPayment = new Payment
            {
                Id = 1,
                PaidOn = new DateTime(2018, 12, 12),
                Amount = 10,
                CashPayment = false,
                MonthlyPaymentConsumableId =1,
                
            };
            var secndPayment = new Payment
            {
                Id = 2,
                PaidOn = new DateTime(2017, 11, 6),
                Amount = 20,
                CashPayment = true,
                MonthlyPaymentConsumableId = 2,
               
            };
            var thirdPayment = new Payment
            {
                Id = 3,
                PaidOn = new DateTime(2015, 11, 12),
                Amount = 30,
                CashPayment = false,
                MonthlyPaymentConsumableId = 3
               
            };
            var forthPayment = new Payment
            {
                Id = 4,
                PaidOn = new DateTime(2015, 12, 15),
                Amount = 40,
                CashPayment = false,
                MonthlyPaymentConsumableId = 4
            };
            var fifthPayment = new Payment
            {
                Id = 5,
                PaidOn = new DateTime(2017, 12, 15),
                Amount = 50,
                MonthlyPaymentConsumableId = null,
                CashPayment = false
            };
            await db.Payments.AddRangeAsync(firstPayment, secndPayment, thirdPayment, forthPayment, fifthPayment);
            await db.SaveChangesAsync();

            var filterModel = new FilterConsumablesBindingModel
            {
                Client = 1,
                OnlyCash = true,
                StartDate = new DateTime(2017, 1, 1),
                EndDate = new DateTime(2018,12,30)
            };
            var paymentService = new PaymentsService(mapper, db, null);
            //Act
            var result = await paymentService.FilterConsumablesAsync(filterModel);
            //Assert
            result
                .Should()
                .BeOfType<FilterConsumablesViewModel>()
                .And                
                .Match<FilterConsumablesViewModel>(x =>x.TotalIncome==20
                    &&x.Payments.Any(y=>y.PaidOn== new DateTime(2017, 11, 6)));
        }

        [Fact]
        public async Task FilterRentsAsync_ShouldReturn_CorrectQueryResult_DependingOnInput()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthConsumable = new MonthlyPaymentRent
            {
                Id = 1,
                RentAgreement = new RentAgreement
                {
                    Id = 1,
                    ClientId = 1
                }
            };
            var secondMonthConsumable = new MonthlyPaymentRent
            {
                Id = 2,
                RentAgreement = new RentAgreement
                {
                    Id = 1,
                    ClientId = 1
                }
            };
            var thirdMonthConsumable = new MonthlyPaymentRent
            {
                Id = 3,
                RentAgreement = new RentAgreement
                {
                    Id = 2,
                    ClientId = 2
                }
            };
            var forthMonthConsumable = new MonthlyPaymentRent
            {
                Id = 4,
                RentAgreement = new RentAgreement
                {
                    Id = 1,
                    ClientId = 1
                }
            };
            await db.MonthlyPaymentRents.AddRangeAsync(firstMonthConsumable, secondMonthConsumable, thirdMonthConsumable, forthMonthConsumable);

            var firstPayment = new Payment
            {
                Id = 1,
                PaidOn = new DateTime(2018, 12, 12),
                Amount = 10,
                CashPayment = false,
                MonthlyPaymentRentId = 1,

            };
            var secndPayment = new Payment
            {
                Id = 2,
                PaidOn = new DateTime(2017, 11, 6),
                Amount = 20,
                CashPayment = true,
                MonthlyPaymentRentId = 2,

            };
            var thirdPayment = new Payment
            {
                Id = 3,
                PaidOn = new DateTime(2015, 11, 12),
                Amount = 30,
                CashPayment = false,
                MonthlyPaymentRentId = 3

            };
            var forthPayment = new Payment
            {
                Id = 4,
                PaidOn = new DateTime(2015, 12, 15),
                Amount = 40,
                CashPayment = false,
                MonthlyPaymentRentId = 4
            };
            var fifthPayment = new Payment
            {
                Id = 5,
                PaidOn = new DateTime(2017, 12, 15),
                Amount = 50,
                MonthlyPaymentRentId = null,
                CashPayment = false
            };
            await db.Payments.AddRangeAsync(firstPayment, secndPayment, thirdPayment, forthPayment, fifthPayment);
            await db.SaveChangesAsync();

            var filterModel = new FilterRentBindingModel
            {
                Client = 1,
                OnlyCash = true,
                StartDate = new DateTime(2017, 1, 1),
                EndDate = new DateTime(2018, 12, 30)
            };
            var paymentService = new PaymentsService(mapper, db, null);
            //Act
            var result = await paymentService.FilterRentsAsync(filterModel);
            //Assert
            result
                .Should()
                .BeOfType<FilterRentsViewModel>()
                .And
                .Match<FilterRentsViewModel>(x => x.TotalIncome == 20
                    && x.Payments.Any(y => y.PaidOn == new DateTime(2017, 11, 6)));
        }

        [Fact]
        public async Task MakeConsumablesPaymentAsync_ShouldReturn_True_WhenInputIsCorrect()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                PaymentForWater=100,
                PaymentForElectricity=200
            };
            var secondMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                PaymentForWater = 200,
                PaymentForElectricity = 300
            };
            var thirdMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 3,
                PaymentForWater = 400,
                PaymentForElectricity = 500
            };            

            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthConsumable, secondMonthConsumable, thirdMonthConsumable);

            var user = new User
            {
                Id ="007"
            };
            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();

            
            var paymentService = new PaymentsService(mapper, db, null);
            //Act
            var result = await paymentService.MakeConsumablesPaymentAsync(2,true,new DateTime(2018,12,12),"007");
            var payment = await db.Payments
                .FirstOrDefaultAsync(x=>x.MonthlyPaymentConsumableId==2);
            //Assert
            result
                .Should()
                .BeTrue();
            payment
                .Should()
                .Match<Payment>(x => x.CashPayment==true
                    && x.UserId=="007"
                    && x.Amount==500);
        }

        [Fact]
        public async Task MakeConsumablesPaymentAsync_ShouldReturn_False_IfMOntlyConsumableNotExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                PaymentForWater = 100,
                PaymentForElectricity = 200
            };
            var secondMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                PaymentForWater = 200,
                PaymentForElectricity = 300
            };
            var thirdMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 3,
                PaymentForWater = 400,
                PaymentForElectricity = 500
            };

            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthConsumable, secondMonthConsumable, thirdMonthConsumable);

            var user = new User
            {
                Id = "007"
            };
            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();


            var paymentService = new PaymentsService(mapper, db, null);
            //Act
            var result = await paymentService.MakeConsumablesPaymentAsync(8, true, new DateTime(2018, 12, 12), "007");
            var payment = await db.Payments
                .FirstOrDefaultAsync(x => x.MonthlyPaymentConsumableId == 8);
            //Assert
            result
                .Should()
                .BeFalse();
            payment
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task MakeConsumablesPaymentAsync_ShouldReturn_False_IfUsrerDoNotExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                PaymentForWater = 100,
                PaymentForElectricity = 200
            };
            var secondMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                PaymentForWater = 200,
                PaymentForElectricity = 300
            };
            var thirdMonthConsumable = new MonthlyPaymentConsumable
            {
                Id = 3,
                PaymentForWater = 400,
                PaymentForElectricity = 500
            };

            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthConsumable, secondMonthConsumable, thirdMonthConsumable);

            var user = new User
            {
                Id = "007"
            };
            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();


            var paymentService = new PaymentsService(mapper, db, null);
            //Act
            var result = await paymentService.MakeConsumablesPaymentAsync(2, true, new DateTime(2018, 12, 12), "069");
            var payment = await db.Payments
                .FirstOrDefaultAsync(x => x.MonthlyPaymentConsumableId == 2);
            //Assert
            result
                .Should()
                .BeFalse();
            payment
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task MakePaymentAsync_ShouldReturn_True_WhenInputIsCorrectAndRentPaymentWillBeClosed()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthRent= new MonthlyPaymentRent
            {
                Id = 1,
                TotalPayment=2000
            };
            await db.MonthlyPaymentRents.AddRangeAsync(firstMonthRent);

            var firstPayment = new Payment {Id=20, Amount = 500,MonthlyPaymentRentId =1 };
            var secndPayment = new Payment {Id=21, Amount = 500,MonthlyPaymentRentId =1 };
            await db.Payments.AddRangeAsync(firstPayment, secndPayment);

            var user = new User
            {
                Id = "007"
            };
            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();


            var monthlyRentMock = new Mock<IMonthlyRentsService>();
            monthlyRentMock
                .Setup(mr => mr.CreateNextMonthPayment(It.IsAny<int>()))
                .ReturnsAsync(true);

            var paymentService = new PaymentsService(mapper, db, monthlyRentMock.Object);

            //Act
            var paymentModel = new BindingMonthlyRentModel
            {
                CashPayment=true,
                MonthlyRentId=1,
                Payment = 1000,
                PaidOn = new DateTime(2018, 12, 12)
            };
            var result = await paymentService.MakePaymentAsync(paymentModel, "007");
            var payment = await db.Payments
                .FirstOrDefaultAsync(x => x.MonthlyPaymentRentId == 1 && x.Amount==1000);
            //Assert
            result
                .Should()
                .BeTrue();
            payment
                .Should()
                .Match<Payment>(x => x.CashPayment == true
                    && x.UserId == "007"
                    && x.Amount == 1000);
        }

        [Fact]
        public async Task MakePaymentAsync_ShouldReturn_Null_WhenInputIsCorrectButNextMonthPaymentFails()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthRent = new MonthlyPaymentRent
            {
                Id = 1,
                TotalPayment = 2000
            };
            await db.MonthlyPaymentRents.AddRangeAsync(firstMonthRent);

            var firstPayment = new Payment { Id = 20, Amount = 500, MonthlyPaymentRentId = 1 };
            var secndPayment = new Payment { Id = 21, Amount = 500, MonthlyPaymentRentId = 1 };
            await db.Payments.AddRangeAsync(firstPayment, secndPayment);

            var user = new User
            {
                Id = "007"
            };
            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();


            var monthlyRentMock = new Mock<IMonthlyRentsService>();
            monthlyRentMock
                .Setup(mr => mr.CreateNextMonthPayment(It.IsAny<int>()))
                .ReturnsAsync(false);

            var paymentService = new PaymentsService(mapper, db, monthlyRentMock.Object);

            //Act
            var paymentModel = new BindingMonthlyRentModel
            {
                CashPayment = true,
                MonthlyRentId = 1,
                Payment = 1000,
                PaidOn = new DateTime(2018, 12, 12)
            };
            var result = await paymentService.MakePaymentAsync(paymentModel, "007");
            var payment = await db.Payments
                .FirstOrDefaultAsync(x => x.MonthlyPaymentRentId == 1 && x.Amount == 1000);
            //Assert
            result
                .Should()
                .BeNull();
            payment
                .Should()
                .Match<Payment>(x => x.CashPayment == true
                    && x.UserId == "007"
                    && x.Amount == 1000);
        }

        [Fact]
        public async Task MakePaymentAsync_ShouldReturn_False_WhenInputIsNotCorrect()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthRent = new MonthlyPaymentRent
            {
                Id = 1,
                TotalPayment = 2000
            };
            await db.MonthlyPaymentRents.AddRangeAsync(firstMonthRent);

            var firstPayment = new Payment { Id = 20, Amount = 500, MonthlyPaymentRentId = 1 };
            var secndPayment = new Payment { Id = 21, Amount = 500, MonthlyPaymentRentId = 1 };
            await db.Payments.AddRangeAsync(firstPayment, secndPayment);

            var user = new User
            {
                Id = "007"
            };
            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();


            var monthlyRentMock = new Mock<IMonthlyRentsService>();
            monthlyRentMock
                .Setup(mr => mr.CreateNextMonthPayment(It.IsAny<int>()))
                .ReturnsAsync(false);

            var paymentService = new PaymentsService(mapper, db, monthlyRentMock.Object);

            //Act
            var paymentModel = new BindingMonthlyRentModel
            {
                CashPayment = true,
                MonthlyRentId = 3,
                Payment = 1000,
                PaidOn = new DateTime(2018, 12, 12)
            };
            var result = await paymentService.MakePaymentAsync(paymentModel, "007");
            var payment = await db.Payments
                .FirstOrDefaultAsync(x => x.MonthlyPaymentRentId == 1 && x.Amount == 1000);
            //Assert
            result
                .Should()
                .BeFalse();
            payment
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task MakePaymentAsync_ShouldReturn_False_WhenUserNotExists()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstMonthRent = new MonthlyPaymentRent
            {
                Id = 1,
                TotalPayment = 2000
            };
            await db.MonthlyPaymentRents.AddRangeAsync(firstMonthRent);

            var firstPayment = new Payment { Id = 20, Amount = 500, MonthlyPaymentRentId = 1 };
            var secndPayment = new Payment { Id = 21, Amount = 500, MonthlyPaymentRentId = 1 };
            await db.Payments.AddRangeAsync(firstPayment, secndPayment);

            var user = new User
            {
                Id = "007"
            };
            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();


            var monthlyRentMock = new Mock<IMonthlyRentsService>();
            monthlyRentMock
                .Setup(mr => mr.CreateNextMonthPayment(It.IsAny<int>()))
                .ReturnsAsync(false);

            var paymentService = new PaymentsService(mapper, db, monthlyRentMock.Object);

            //Act
            var paymentModel = new BindingMonthlyRentModel
            {
                CashPayment = true,
                MonthlyRentId = 1,
                Payment = 1000,
                PaidOn = new DateTime(2018, 12, 12)
            };
            var result = await paymentService.MakePaymentAsync(paymentModel, "069");
            var payment = await db.Payments
                .FirstOrDefaultAsync(x => x.MonthlyPaymentRentId == 1 && x.Amount == 1000);
            //Assert
            result
                .Should()
                .BeFalse();
            payment
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task MonthIncomeStatisctic_ShouldReturn_CorrectStatisctic()
        {
            var db = GetDatabase();
            var mapper = GetMapper();

            var firstRent = new RentAgreement
            {
                Id=1,
                MonthlyPrice=100,
                ParkingSlots = new List<ParkingSlot>
                {
                    new ParkingSlot {Id=1,Price=1,Quantity=10,Area = ParkingSlotArea.BackParking },
                    new ParkingSlot {Id=2,Price=5,Quantity=11,Area = ParkingSlotArea.FrontParking },
                    new ParkingSlot {Id=3,Price=10,Quantity=20,Area = ParkingSlotArea.NoReserved },
                },
                MonthlyConsumables = new List<MonthlyPaymentConsumable>
                {
                    new MonthlyPaymentConsumable
                    {
                        Id =1,
                        PaymentForElectricity =250,
                        PaymentForWater =150,
                        Payment = new Payment {Id=1,Amount=400,PaidOn=new DateTime(2018,6,6),CashPayment = true}, //this payment to be include in statistic
                        DeadLine = new DateTime(2018,6,3)                        
                    },
                     new MonthlyPaymentConsumable
                    {
                        Id =2,
                        PaymentForElectricity =150,
                        PaymentForWater =150,
                        Payment = new Payment {Id=2,Amount=300,PaidOn=new DateTime(2018,7,6),CashPayment = false},
                        DeadLine = new DateTime(2018,7,3)
                    },
                },
                MonthlyRents = new List<MonthlyPaymentRent>
                {
                    new MonthlyPaymentRent
                    {
                        Id=1,
                        ApplyVAT=true,
                        Payments = new List<Payment>
                        {
                            new Payment {Id=3,PaidOn = new DateTime(2018,6,6),Amount = 238, CashPayment=true }, //this payment to be include in statistic
                            new Payment {Id=4,PaidOn = new DateTime(2018,6,10),Amount = 200, CashPayment=false }, //this payment to be include in statistic
                        },
                        DeadLine = new DateTime(2018,6,3)

                    },
                    new MonthlyPaymentRent
                    {
                        Id=2,
                        ApplyVAT=true,
                        Payments = new List<Payment>
                        {
                            new Payment {Id=5,PaidOn = new DateTime(2018,7,6),Amount = 438, CashPayment=false },
                        },
                        DeadLine = new DateTime(2018,7,3)
                    }
                }                
            };
            var secondRent = new RentAgreement
            {
                Id = 2,
                MonthlyPrice = 1000,
                ParkingSlots = new List<ParkingSlot>
                {
                    new ParkingSlot {Id=4,Price=1,Quantity=10,Area = ParkingSlotArea.BackParking },
                    new ParkingSlot {Id=5,Price=5,Quantity=11,Area = ParkingSlotArea.FrontParking },
                    new ParkingSlot {Id=6,Price=10,Quantity=20,Area = ParkingSlotArea.NoReserved },
                },
                MonthlyConsumables = new List<MonthlyPaymentConsumable>
                {
                    new MonthlyPaymentConsumable
                    {
                        Id =3,
                        PaymentForElectricity =250,
                        PaymentForWater =150,
                        Payment = new Payment {Id=6,Amount=400,PaidOn=new DateTime(2018,8,6),CashPayment = true}, 
                        DeadLine = new DateTime(2018,8,3)

                    },
                     new MonthlyPaymentConsumable
                    {
                        Id =4,
                        PaymentForElectricity =150,
                        PaymentForWater =150,
                        Payment = new Payment {Id=7,Amount=300,PaidOn=new DateTime(2018,9,6),CashPayment = false},
                        DeadLine = new DateTime(2018,9,3)
                    },
                },
                MonthlyRents = new List<MonthlyPaymentRent>
                {
                    new MonthlyPaymentRent
                    {
                        Id=3,
                        ApplyVAT=true,
                        Payments = new List<Payment>
                        {
                            new Payment {Id=8,PaidOn = new DateTime(2018,8,6),Amount = 238, CashPayment=true },
                            new Payment {Id=9,PaidOn = new DateTime(2018,8,10),Amount = 200, CashPayment=false },

                        },
                        DeadLine = new DateTime(2018,8,3)

                    },
                    new MonthlyPaymentRent
                    {
                        Id=4,
                        ApplyVAT=true,
                        Payments = new List<Payment>
                        {
                            new Payment {Id=10,PaidOn = new DateTime(2018,9,6),Amount = 438, CashPayment=false },
                        },
                        DeadLine = new DateTime(2018,9,3)

                    }
                }
            };

            await db.RentAgreements.AddRangeAsync(firstRent, secondRent);
            await db.SaveChangesAsync();
            var paymentService = new PaymentsService(mapper, db, null);
            //Act
            var result = await paymentService.MonthIncomeStatistic(new DateTime(2018, 6, 20));
            //Assert
            result
                .Should()
                .Match<MonthlyPaymentStatisticView>(x =>
                x.ConsumablesInCash==400
                && x.RentInCash==238
                && x.TotalConsumablesPayment==400
                && x.TotalRentPayment==438
                && x.VAT==73
                && x.IncomeBackParking==10
                && x.IncomeFronParking==55
                && x.IncomeNoReservedParking==200);
        }

        private EstateManagmentContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<EstateManagmentContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var db = new EstateManagmentContext(dbOptions);

            return db;
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }
    }
}
