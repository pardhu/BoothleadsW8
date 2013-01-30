using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BoothLeads.BoothLeadsEntity
{
    public class BldbEventSchedule
    {
        public string EsId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramStartHour { get; set; }
        public string ProgramEndHour { get; set; }
        public string ProgramStartDate { get; set; }
        public string ProgramEndDate { get; set; }
        public string Programdescription { get; set; }
        public string ProgramLocation { get; set; }
        public string Programpresenter { get; set; }
    }
}
