﻿using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;

namespace MyAD.Helper
{
    public class ClipboardAsync
    {
        private bool _ContainsFileDropList;

        private bool _ContainsText;

        private StringCollection _GetFileDropList;

        private string _GetText;

        private void _thGetText(object format)
        {
            try
            {
                _GetText = format == null ? Clipboard.GetText() : Clipboard.GetText((TextDataFormat)format);
            }
            catch (Exception ex)
            {
                //Throw ex
                _GetText = string.Empty;
            }
        }

        public string GetText()
        {
            var instance = new ClipboardAsync();
            var staThread = new Thread(instance._thGetText);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return instance._GetText;
        }

        public string GetText(TextDataFormat format)
        {
            var instance = new ClipboardAsync();
            var staThread = new Thread(instance._thGetText);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start(format);
            staThread.Join();
            return instance._GetText;
        }

        private void _thContainsText(object format)
        {
            try
            {
                _ContainsText = format == null ? Clipboard.ContainsText() : Clipboard.ContainsText((TextDataFormat)format);
            }
            catch (Exception ex)
            {
                //Throw ex
                _ContainsText = false;
            }
        }

        public bool ContainsText()
        {
            var instance = new ClipboardAsync();
            var staThread = new Thread(instance._thContainsFileDropList);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return instance._ContainsText;
        }

        public bool ContainsText(object format)
        {
            var instance = new ClipboardAsync();
            var staThread = new Thread(instance._thContainsFileDropList);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start(format);
            staThread.Join();
            return instance._ContainsText;
        }

        private void _thContainsFileDropList(object format)
        {
            try
            {
                _ContainsFileDropList = Clipboard.ContainsFileDropList();
            }
            catch (Exception ex)
            {
                //Throw ex
                _ContainsFileDropList = false;
            }
        }

        public bool ContainsFileDropList()
        {
            var instance = new ClipboardAsync();
            var staThread = new Thread(instance._thContainsFileDropList);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return instance._ContainsFileDropList;
        }

        private void _thGetFileDropList()
        {
            try
            {
                _GetFileDropList = Clipboard.GetFileDropList();
            }
            catch (Exception ex)
            {
                //Throw ex
                _GetFileDropList = null;
            }
        }

        public StringCollection GetFileDropList()
        {
            var instance = new ClipboardAsync();
            var staThread = new Thread(instance._thGetFileDropList);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return instance._GetFileDropList;
        }
    }
}