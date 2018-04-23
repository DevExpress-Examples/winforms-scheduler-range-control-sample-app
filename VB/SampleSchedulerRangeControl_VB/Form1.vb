Imports System.ComponentModel
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins


Public Class Form1
    Sub New()
        InitSkins()
        InitializeComponent()
        Me.InitSkinGallery()
        schedulerControl.Start = DateTime.Now
        AddHandler schedulerStorage.AppointmentsChanged, AddressOf schedulerStorage_AppointmentsChanged
        AddHandler schedulerStorage.AppointmentsInserted, AddressOf schedulerStorage_AppointmentsInserted
        AddHandler schedulerStorage.AppointmentsDeleted, AddressOf schedulerStorage_AppointmentsDeleted
        schedulerStorage.Appointments.CommitIdToDataSource = False
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")

    End Sub
    Private Sub InitSkinGallery()
        SkinHelper.InitSkinGallery(rgbiSkins, True)
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CarsDBDataSet.Cars' table. You can move, or remove it, as needed.
        Me.CarsTableAdapter.Fill(Me.CarsDBDataSet.Cars)
        'TODO: This line of code loads data into the 'CarsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
        Me.CarSchedulingTableAdapter.Fill(Me.CarsDBDataSet.CarScheduling)

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
