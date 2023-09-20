Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers

Namespace SampleSchedulerRangeControl

    Public Partial Class Form1
        Inherits RibbonForm

        Public Sub New()
            InitializeComponent()
            InitSkinGallery()
            schedulerControl.Start = Date.Now
            AddHandler schedulerStorage.AppointmentsChanged, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf schedulerStorage_AppointmentsChanged)
            AddHandler schedulerStorage.AppointmentsInserted, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf schedulerStorage_AppointmentsInserted)
            AddHandler schedulerStorage.AppointmentsDeleted, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf schedulerStorage_AppointmentsDeleted)
            schedulerStorage.Appointments.CommitIdToDataSource = False
        End Sub

        Private Sub InitSkinGallery()
            Call SkinHelper.InitSkinGallery(rgbiSkins, True)
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
            carsTableAdapter.Fill(carsDBDataSet.Cars)
            ' TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            carSchedulingTableAdapter.Fill(carsDBDataSet.CarScheduling)
        End Sub

        Private Sub schedulerStorage_AppointmentsDeleted(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs)
            Commit()
        End Sub

        Private Sub schedulerStorage_AppointmentsInserted(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs)
            Commit()
        End Sub

        Private Sub schedulerStorage_AppointmentsChanged(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs)
            Commit()
        End Sub

        Private Sub Commit()
            carSchedulingTableAdapter.Update(carsDBDataSet)
            carsDBDataSet.AcceptChanges()
        End Sub
    End Class
End Namespace
