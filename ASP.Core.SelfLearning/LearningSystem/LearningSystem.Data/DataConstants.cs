﻿namespace LearningSystem.Data
{
    public  static class DataConstants
    {
        public const int ArticleTitleMinLength = 3;
        public const int ArticleTitleMaxLength = 100;

        public const int  UserNameMinLength = 2;
        public const int  UserNameMaxLength = 100;

        public const int CourseNameMinLength = 2;
        public const int CourseNameMaxLength = 50;
        public const int CourseDescriptionMaxLength = 200;

        public const int CourseExamSybmissionFileMaxLength = 2*1024*1024; // 2 MB
    }
}
