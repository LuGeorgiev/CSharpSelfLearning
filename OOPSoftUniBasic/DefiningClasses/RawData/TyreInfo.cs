using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class TyreInfo
    {
        private int tyre1Age;
        private double tyre1Pressure;

        public int Tyre1Age
        {
            get { return tyre1Age; }
            private set { tyre1Age = value; }
        }
        public double Tyre1Presure
        {
            get { return tyre1Pressure; }
            private set { tyre1Pressure = value; }
        }

        private int tyre2Age;
        private double tyre2Pressure;

        public int Tyre2Age
        {
            get { return tyre2Age; }
            private set { tyre2Age = value; }
        }
        public double Tyre2Presure
        {
            get { return tyre2Pressure; }
            private set { tyre2Pressure = value; }
        }

        private int tyre3Age;
        private double tyre3Pressure;

        public int Tyre3Age
        {
            get { return tyre3Age; }
            private set { tyre3Age = value; }
        }
        public double Tyre3Presure
        {
            get { return tyre3Pressure; }
            private set { tyre3Pressure = value; }
        }

        private int tyre4Age;
        private double tyre4Pressure;

        public int Tyre4Age
        {
            get { return tyre4Age; }
            private set { tyre4Age = value; }
        }
        public double Tyre4Presure
        {
            get { return tyre4Pressure; }
            private set { tyre4Pressure = value; }
        }

        public TyreInfo(int tyre1Age, double tyre1pres, int tyre2Age, double tyre2pres, int tyre3Age, double tyre3pres, int tyre4Age, double tyre4pres)
        {
            this.tyre1Age = tyre1Age;
            this.Tyre1Presure = tyre1pres;

            this.tyre2Age = tyre2Age;
            this.Tyre2Presure = tyre2pres;

            this.tyre3Age = tyre3Age;
            this.Tyre3Presure = tyre3pres;

            this.tyre4Age = tyre4Age;
            this.Tyre4Presure = tyre4pres;
        }
    }
}
