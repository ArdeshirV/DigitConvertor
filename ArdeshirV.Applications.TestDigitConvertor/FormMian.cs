#region Header
// FormMain.cs : Main form of 'TestDigitiConvetor' windows-form application
// Copyright© 2010-2021 ArdeshirV@protonmail.com, Licensed under GPLv3+

using System;
using ArdeshirV.Forms;
using System.Windows.Forms;
using ArdeshirV.Tools.DigitConvertor;
using ArdeshirV.Applications.TestDigitConvertor.Properties;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Applications.TestDigitConvertor
{
	/// <summary>
	/// Main form of 'TestDigitiConvetor' windows-form application
	/// </summary>
	public partial class FormMain : FormBase
	{
		#region Variables
		
		private const string _stringEmail = "ArdeshirV@protonmail.com";
		private const string _stringWebsite = "https://ArdeshirV.github.io/DigitConvertor/";
		
		#endregion
		//-------------------------------------------------------------------------------		
		#region Constructor

		public FormMain()
		{
			InitializeComponent();
			nupdownNumber.Minimum = decimal.MinValue;
			nupdownNumber.Maximum = decimal.MaxValue;
			nupdownNumber.Value = 0;
		}
		
		#endregion Constructor
		//-------------------------------------------------------------------------------
		#region Utility Methods

		private void SelectInputText()
		{
			nupdownNumber.Select(0, nupdownNumber.Value.ToString().Length);
		}
		
		#endregion Utility Methods
		//-------------------------------------------------------------------------------
		#region Event Handlers

		void FormMainShown(object sender, EventArgs e)
		{
			SelectInputText();
			nupdownNumber.Focus();
		}
		//-------------------------------------------------------------------------------
		void NupdownNumberValueChanged(object sender, EventArgs e)
		{
			textboxOutput.Text =
				DigitConvertor.ConvertDigitalNumberToPersian(
					nupdownNumber.Value
				);
		}
		//-------------------------------------------------------------------------------
		void NupdownNumberKeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
				SelectInputText();
		}
		//-------------------------------------------------------------------------------
		void ButtonCopyClick(object sender, EventArgs e)
		{
			Clipboard.SetText(textboxOutput.Text, TextDataFormat.UnicodeText);
		}
		//-------------------------------------------------------------------------------
		void ButtonFormAboutClick(object sender, EventArgs e)
		{
			string stringAssemblyProductName = Application.ProductName;

			Donations[] donations = new Donations[] {
				new Donations( 
				stringAssemblyProductName,
				DefaultDonationList.Items)};
			
			const string stringCreditDesc = 
@"ArdeshirV is creator and developer of ""DigitConvertor""
DigitConvertor: https://ardeshirv.github.io/DigitConvertor/
Github: https://github.com/ArdeshirV/DigitConvertor
Email: ArdeshirV@protonmail.com";
			Credits[] credits = new Credits[] {
				new Credits(stringAssemblyProductName, new Credit[] {
				            	new Credit(
				            		"ArdeshirV",
				            		stringCreditDesc, GlobalResouces.AuthorsPhotos.ArdeshirV)
				            })
			};
			
			Copyright[] copyrights = new Copyright[] {
				new Copyright(this, DigitConvertor.Logo),
				new Copyright(new DigitConvertorType(), DigitConvertor.Logo)
			};
			
			License[] licenses = new License[] {
				new License(stringAssemblyProductName,
				            GlobalResouces.Licenses.GPLLicense,
				            GlobalResouces.Licenses.GPLLicenseLogo)
			};
			
        	FormAboutData data = new FormAboutData(this,
        	                                       copyrights,
        	                                       credits,
        	                                       licenses,
        	                                       donations,
        	                                       _stringWebsite,
        	                                       _stringEmail);
        	FormAbout.Show(data);
		}
		//-------------------------------------------------------------------------------
		void ButtonExitClick(object sender, EventArgs e)
		{
			Close();
		}

		#endregion Event Handlers
	}
}
