﻿namespace Survey.WebUI.Data.Questionnaires
{
    public class QuestionnaireListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string StatusName { get; set; }
    }
}