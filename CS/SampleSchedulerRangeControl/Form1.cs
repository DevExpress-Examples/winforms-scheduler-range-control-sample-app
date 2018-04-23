using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;


namespace SampleSchedulerRangeControl
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            schedulerControl.Start = System.DateTime.Now;

            schedulerStorage.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(schedulerStorage_AppointmentsChanged);
            schedulerStorage.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(schedulerStorage_AppointmentsInserted);
            schedulerStorage.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(schedulerStorage_AppointmentsDeleted);

            schedulerStorage.Appointments.CommitIdToDataSource = false;
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDBDataSet.Cars);
            // TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            this.carSchedulingTableAdapter.Fill(this.carsDBDataSet.CarScheduling);

        }

        void schedulerStorage_AppointmentsDeleted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            Commit();
        }

        void schedulerStorage_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            Commit();
        }

        void schedulerStorage_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            Commit();
        }

        private void Commit()
        {
            carSchedulingTableAdapter.Update(carsDBDataSet);
            carsDBDataSet.AcceptChanges();
        }

    }
}