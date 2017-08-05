using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webControlTest
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    public class ServerControl1 : WebControl
    {
        // public const string webControl = "2a8b9574-6620-4df2-a36d-e8012bf624ba";
        private Button submitButton;
        private TextBox nameTextbox;
        private Label namelbl;
        private TextBox emailTextbox;
        private Label emaillbl;
        private RequiredFieldValidator emailValidator;
        private RequiredFieldValidator nameValidator;
        private RegularExpressionValidator emailEV;
        private Label phonelbl;
        private TextBox phoneTextbox;
        private RegularExpressionValidator phoneEV;

        private static readonly object EventSubmitKey = new object();
        //private string imageheight = "100";

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("The text to display on the button")]
        public string ButtonText
        {
            get
            {
                EnsureChildControls();
                return submitButton.Text;
            }
            set
            {
                EnsureChildControls();
                submitButton.Text = value;
            }
        }

        [Bindable(true)]
        [Category("Default")]
        [DefaultValue("")]
        [Description("The user name.")]
        public string name
        {
            get
            {
                EnsureChildControls();
                return nameTextbox.Text;
            }
            set
            {
                EnsureChildControls();
                nameTextbox.Text = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("*")]
        [Description("Error massage for the name validator.")]
        public string NameErrorMessage
        {
            get
            {
                EnsureChildControls();
                return nameValidator.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                nameValidator.ErrorMessage = value;
                nameValidator.ToolTip = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("The text for the name label.")]
        public string NameLabelText
        {
            get
            {
                EnsureChildControls();
                return namelbl.Text;
            }
            set
            {
                EnsureChildControls();
                namelbl.Text = value;
            }
        }

        [Bindable(true)]
        [Category("Default")]
        [DefaultValue("")]
        [Description("The e-mail address.")]
        public string Email
        {
            get
            {
                EnsureChildControls();
                return emailTextbox.Text;
            }
            set
            {
                EnsureChildControls();
                emailTextbox.Text = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("格式不符合要求！")]
        [Description("Error message for e-mail validator.")]
        public string EmailEVMessage
        {
            get
            {
                EnsureChildControls();
                return emailValidator.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                emailEV.ErrorMessage =  value;
                emailEV.ToolTip =  value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("Error message for e-mail validator.")]
        public string EmailErrorMessage
        {
            get
            {
                EnsureChildControls();
                return emailValidator.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                emailValidator.ErrorMessage = value;
                emailValidator.ToolTip = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("The text for the e-mail label.")]
        public string EmailLabelText
        {
            get
            {
                EnsureChildControls();
                return emaillbl.Text;
            }
            set
            {
                EnsureChildControls();
                emaillbl.Text = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("phone number:")]
        [Description("The text for the e-mail label.")]
        public string phoneLabelText
        {
            get
            {
                EnsureChildControls();
                return phonelbl.Text;
            }
            set
            {
                EnsureChildControls();
                phonelbl.Text = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Format error.")]
        [Description("Error message for e-mail validator.")]
        public string phoneErrorMessage
        {
            get
            {
                EnsureChildControls();
                return phoneEV.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                phoneEV.ErrorMessage = value;
                phoneEV.ToolTip = value;
            }
        }

        // The Submit event
        [Category("Action")]
        [Description("Raised when the user clicks the button.")]
        public event EventHandler Sumbit
        {
            add
            {
                Events.AddHandler(EventSubmitKey, value);
            }
            remove
            {
                Events.RemoveHandler(EventSubmitKey, value);
            }
        }

        // The method that raises the Submit event
        protected virtual void OnSubmit(EventArgs e)
        {
            EventHandler SubmitHandler = (EventHandler)Events[EventSubmitKey];
            if (null != SubmitHandler)
            {
                SubmitHandler(this,e);
            }
        }

        // Handler the Click event of the Button and raises the Submit event
        private void _button_Click(object source, EventArgs e)
        {
            OnSubmit(EventArgs.Empty);
        }

        //protected override void RecreateChildControls()
        //{
        //    // base.RecreateChildControls();
        //    EnsureChildControls();
        //}


        protected override void CreateChildControls()
        {
            //Control.Clear();
            namelbl = new Label();

            nameTextbox = new TextBox();
            nameTextbox.ID = "nameTextBox";

            nameValidator = new RequiredFieldValidator();
            nameValidator.ID = "validator";
            nameValidator.ControlToValidate = nameTextbox.ID;
            nameValidator.Text = "Failed validation";
            nameValidator.Display = ValidatorDisplay.Static;

            emaillbl = new Label();
            emailTextbox = new TextBox();
            emailTextbox.ID = "emailTextBox";

            emailValidator = new RequiredFieldValidator();
            emailValidator.ID = "validator2";
            emailValidator.ControlToValidate = emailTextbox.ID;
            emailValidator.Text = "Failed validation.";
            emailValidator.Display = ValidatorDisplay.Dynamic;

            emailEV = new RegularExpressionValidator();
            emailEV.ID = "validator3";
            emailEV.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            emailEV.ControlToValidate = emailTextbox.ID;
            emailEV.Text = "Format error.";
            emailEV.Display = ValidatorDisplay.Dynamic;


            phonelbl = new Label();
            phoneTextbox = new TextBox();
            phoneTextbox.ID = "phoneTextBox";

            phoneEV = new RegularExpressionValidator();
            phoneEV.ID = "validator4";
            phoneEV.ValidationExpression = @"^1[0-9]{10}$";
            phoneEV.ControlToValidate = phoneTextbox.ID;
            phoneEV.Text = "Format error.";
           // phoneEV.BackColor = 
            phoneEV.Display = ValidatorDisplay.Dynamic;


            submitButton = new Button();
            submitButton.ID = "button";
            submitButton.Width = 100;
            submitButton.Click += new EventHandler(_button_Click);

            this.Controls.Add(namelbl);
            this.Controls.Add(nameTextbox);
            this.Controls.Add(nameValidator);
            this.Controls.Add(emaillbl);
            this.Controls.Add(emailTextbox);
            this.Controls.Add(emailValidator);
            this.Controls.Add(emailEV);
            this.Controls.Add(submitButton);
            this.Controls.Add(phonelbl);
            this.Controls.Add(phoneTextbox);
            this.Controls.Add(phoneEV);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            // base.Render(writer);
            AddAttributesToRender(writer);

            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "1", false);
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            namelbl.RenderControl(writer);

            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            nameTextbox.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            nameValidator.RenderControl(writer);

            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            emaillbl.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            emailTextbox.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            emailValidator.RenderControl(writer);
            emailEV.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            phonelbl.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            phoneTextbox.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            phoneEV.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan, "2", false);
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "right", false);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            submitButton.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write("&nbsp;");
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderEndTag();
        }


        //protected override void RenderContents(HtmlTextWriter output)
        //{
        //    output.Write(Text);
        //}
    }
}
