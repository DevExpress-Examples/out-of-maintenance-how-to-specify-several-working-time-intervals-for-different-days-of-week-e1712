Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.XtraScheduler

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ASPxScheduler1.ActiveViewType = SchedulerViewType.WorkWeek
		ASPxScheduler1.WorkWeekView.WorkTime = New TimeOfDayInterval(New TimeSpan(8, 0, 0), New TimeSpan(18, 0, 0))
		ASPxScheduler1.WorkWeekView.ShowWorkTimeOnly = True


	End Sub
	Protected Sub ASPxScheduler1_QueryWorkTime(ByVal sender As Object, ByVal e As QueryWorkTimeEventArgs)
		Select Case e.Interval.Start.DayOfWeek
			Case DayOfWeek.Monday
				e.WorkTimes.Add(New TimeOfDayInterval(TimeSpan.FromHours(8), TimeSpan.FromHours(12)))
				e.WorkTimes.Add(New TimeOfDayInterval(TimeSpan.FromHours(13), TimeSpan.FromHours(17)))
			Case DayOfWeek.Friday
				e.WorkTimes.Add(New TimeOfDayInterval(TimeSpan.FromHours(10), TimeSpan.FromHours(14)))
			Case Else
				e.WorkTimes.Add(New TimeOfDayInterval(TimeSpan.FromHours(9), TimeSpan.FromHours(13)))
				e.WorkTimes.Add(New TimeOfDayInterval(TimeSpan.FromHours(14), TimeSpan.FromHours(18)))
		End Select
	End Sub
End Class
