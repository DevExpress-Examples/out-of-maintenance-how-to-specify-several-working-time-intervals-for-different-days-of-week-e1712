using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.XtraScheduler;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        ASPxScheduler1.ActiveViewType = SchedulerViewType.WorkWeek;
        ASPxScheduler1.WorkWeekView.WorkTime =
            new TimeOfDayInterval(new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0));
        ASPxScheduler1.WorkWeekView.ShowWorkTimeOnly = true;


    }
    protected void ASPxScheduler1_QueryWorkTime(object sender, QueryWorkTimeEventArgs e) {
        switch(e.Interval.Start.DayOfWeek) {
            case DayOfWeek.Monday:
                e.WorkTimes.Add(new TimeOfDayInterval(TimeSpan.FromHours(8), TimeSpan.FromHours(12)));
                e.WorkTimes.Add(new TimeOfDayInterval(TimeSpan.FromHours(13), TimeSpan.FromHours(17)));
                break;
            case DayOfWeek.Friday:
                e.WorkTimes.Add(new TimeOfDayInterval(TimeSpan.FromHours(10), TimeSpan.FromHours(14)));
                break;
            default:
                e.WorkTimes.Add(new TimeOfDayInterval(TimeSpan.FromHours(9), TimeSpan.FromHours(13)));
                e.WorkTimes.Add(new TimeOfDayInterval(TimeSpan.FromHours(14), TimeSpan.FromHours(18)));
                break;
        }
    }
}
