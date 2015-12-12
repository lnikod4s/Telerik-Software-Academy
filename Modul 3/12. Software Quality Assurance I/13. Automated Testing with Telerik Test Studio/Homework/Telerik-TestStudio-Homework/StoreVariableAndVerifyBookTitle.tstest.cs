using Telerik.TestingFramework.Controls.KendoUI;
using Telerik.WebAii.Controls.Html;
using Telerik.WebAii.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Test_Studio_Homework
{

    public class StoreVariableAndVerifyBookTitle : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
        public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        #endregion
        
        // Add your test methods here...
    
        //[CodedStep(@"Verify 'TextContent' 'Contains' 'Цена за доставка на 1 бр. JavaScript For Dummies - Ричард Уогнър:' on 'ЦенаЗаBTag'")]
        //public void WebTest_CodedStep()
        //{
            //// Verify 'TextContent' 'Contains' 'Цена за доставка на 1 бр. JavaScript For Dummies - Ричард Уогнър:' on 'ЦенаЗаBTag'
            //Pages.StoreBg.ЦенаЗаBTag.AssertContent().TextContent(ArtOfTest.Common.StringCompareType.Contains, "Цена за доставка на 1 бр. $(JavaScriptBTag) For Dummies - Ричард Уогнър:");
            
        //}
    
        [CodedStep(@"Click 'JavaScriptH3Tag'")]
        public void WebTest_CodedStep1()
        {
            // Click 'JavaScriptH3Tag'
            Pages.StoreBgКнигиJavaScript0.JavaScriptH3Tag.Click(false);
            
        }
    
        [CodedStep(@"Wait for Exists 'ЩракнетеТукLink'")]
        public void StoreVariableAndVerifyBookTitle_CodedStep()
        {
            // Wait for Exists 'ЩракнетеТукLink'
            Pages.StoreBgJavaScriptFor.ЩракнетеТукLink.Wait.ForExists(30000);
        }
    }
}
