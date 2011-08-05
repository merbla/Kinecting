/////////////////////////////////////////////////////////////////////////
//
// Copyright © Microsoft Corporation.  All rights reserved.  
// This code is a “supplement” under the terms of the 
// Microsoft Kinect for Windows SDK (Beta) from Microsoft Research 
// License Agreement: http://research.microsoft.com/KinectSDK-ToU
// and is licensed under the terms of that license agreement. 
//
/////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;



namespace Microsoft.Research.Kinect.Samples.KinectPaint
{
    /// <summary>
    /// Converts any non-null value into Visibility.Visible, and any null value into Visibility.Collapsed
    /// </summary>
    public class VisibleIfPresentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            else return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
