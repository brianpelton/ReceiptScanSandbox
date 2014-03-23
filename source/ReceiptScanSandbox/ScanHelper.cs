using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CommonWin32;
using NTwain;
using NTwain.Data;
using NTwain.Values;

namespace ReceiptScanSandbox
{
    public class ScanHelper : BaseViewModelEmpty
    {
        #region [ Fields ]

        private readonly Form _form;
        private TwainSession _twain;

        #endregion

        #region [ Constructors ]

        public ScanHelper(Form form)
        {
            _form = form;
            PropertyChanged += ScanHelper_PropertyChanged;
        }

        #endregion

        #region [ Properties ]

        public bool CanStartScan { get; private set; }
        public bool CanStopScan { get; private set; }
        public Image ScannedImage { get; private set; }
        public List<TWIdentity> Scanners { get; private set; }
        public TWIdentity SelectedScanner { get; set; }
        public bool StopScan { get; set; }

        #endregion

        #region [ Public Methods ]

        public void CleanupTwain()
        {
            Application.RemoveMessageFilter(_twain);
            if (_twain.State == 4)
            {
                _twain.CloseSource();
            }
            if (_twain.State == 3)
            {
                _twain.CloseManager();
            }

            if (_twain.State > 2)
            {
                // normal close down didn't work, do hard kill
                _twain.ForceStepDown(2);
            }
        }

        public void ReloadScanners()
        {
            Scanners = new List<TWIdentity>();

            if (_twain.State < 3)
            {
                _twain.OpenManager(new HandleRef(this, _form.Handle));
            }

            if (_twain.State >= 3)
            {
                foreach (TWIdentity src in _twain.GetSources())
                {
                    Scanners.Add(src);
                }
            }
        }


        public void SetupTwain()
        {
            FileVersionInfo appVer = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

            TWIdentity appId = TWIdentity.Create(DataGroups.Image,
                new Version(appVer.ProductMajorPart, appVer.ProductMinorPart),
                "My Company", "Test Family", "Tester", "A TWAIN testing app.");
            _twain = new TwainSession(appId);
            _twain.DataTransferred += (s, e) =>
            {
                if (ScannedImage != null)
                {
                    //dispose
                }
                if (e.Data != IntPtr.Zero)
                {
                    //_ptrTest = e.Data;
                    Bitmap img = e.Data.GetDrawingBitmap();
                    if (img != null)
                        ScannedImage = img;
                }
                else if (!string.IsNullOrEmpty(e.FilePath))
                {
                    var img = new Bitmap(e.FilePath);
                    ScannedImage = img;
                }
            };
            _twain.SourceDisabled += (s, e) =>
            {
                CanStopScan = false;
                CanStartScan = false;
                //panelOptions.Enabled = true;
                //LoadSourceCaps();
            };
            _twain.TransferReady += (s, e) => { e.CancelAll = StopScan; };
            Application.AddMessageFilter(_twain);
        }

        public void StartCapture()
        {
            if (_twain.State == 4)
            {
                var hand = new HandleRef(this, _form.Handle);
                StopScan = false;

                if (_twain.SupportedCaps.Contains(CapabilityId.CapUIControllable))
                {
                    // hide scanner ui if possible
                    if (_twain.EnableSource(SourceEnableMode.NoUI, false, hand) == ReturnCode.Success)
                    {
                        CanStopScan = true;
                        CanStartScan = false;
                        //panelOptions.Enabled = false;
                    }
                }
                else
                {
                    if (_twain.EnableSource(SourceEnableMode.ShowUI, false, hand) == ReturnCode.Success)
                    {
                        CanStopScan = true;
                        CanStartScan = false;
                        //panelOptions.Enabled = false;
                    }
                }
            }
        }

        #endregion

        #region [ Event Handlers ]

        private void ScanHelper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedScanner")
            {
                if (_twain.State > 4)
                    return;

                if (_twain.State == 4)
                    _twain.CloseSource();

                if (_twain.OpenSource(SelectedScanner) == ReturnCode.Success)
                {
                    CanStartScan = true;
                }
            }
        }

        #endregion
    }
}