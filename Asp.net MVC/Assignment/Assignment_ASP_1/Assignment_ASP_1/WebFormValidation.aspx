<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormValidation.aspx.cs" Inherits="Assignment_ASP_1.WebFormValidation" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>validation...</title>
<style>
    body {
        font-family: Arial, sans-serif;
        background-color: #f5f5f5;
        margin: 0;
        padding: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        min-height: 100vh;
    }

    #form1 {
        width: 400px;
        margin: 50px auto;
        background-color: #ffeeba; /* Change form background color */
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    h1 {
        color: #6c757d; /* Change heading color */
        text-align: center;
        font-size: 24px; /* Increase heading font size */
    }

    label {
        display: block;
        font-weight: bold;
        margin-bottom: 5px;
        color: #333; /* Change label color */
    }

    input[type="text"] {
        width: calc(100% - 22px); /* Adjusted for border and padding */
        padding: 10px;
        margin-bottom: 15px;
        border: 1px solid #ccc;
        border-radius: 5px;
        box-sizing: border-box;
    }

    input[type="submit"] {
        width: 100%;
        padding: 12px;
        background-color: #28a745; /* Change submit button color */
        color: #fff;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 16px;
    }

    input[type="submit"]:hover {
        background-color: #218838; /* Change submit button hover color */
    }

    .error-message {
        color: #dc3545; /* Change error message color */
        font-style: italic;
        margin-bottom: 10px;
    }

    .validation-summary {
        color: #dc3545; /* Change validation summary color */
        text-align: center;
        margin-top: 20px;
    }
</style>


</head>

 
<body>
<form id="form1" runat="server">
<div>
<h1 style="color:blue;font-size:20px;text-align:center;">Registration Form </h1>
<hr height="4";color="black" />
<br />
<label for="txtName">Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
&nbsp;<asp:TextBox ID="txtName" runat="server" Width="200px" BackColor="#FFFFCC" BorderStyle="None" Height="30px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredNameValidator" runat="server" ControlToValidate="txtName" ErrorMessage="Name is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
<label for="familyname">
<br />
            Family Name:</label>
<asp:TextBox ID="txtFamilyName" runat="server" Width="200px" BackColor="#FFFFCC" ForeColor="Black" BorderStyle="None" Height="30px"></asp:TextBox>
<asp:RequiredFieldValidator CssClass="error-message" ID="RequiredFamilyNameValidator" runat="server" ControlToValidate="txtFamilyName" ErrorMessage="Family Name is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:CompareValidator CssClass="error-message" ID="CompareNameValidator" runat="server" ControlToValidate="txtName" ControlToCompare="txtFamilyName" Operator="NotEqual" ErrorMessage="Family Name must be different from Name" ForeColor="Red"></asp:CompareValidator>
<label for="txtAddress">
<br />
            Address:</label>
<asp:TextBox ID="txtAddress" runat="server" Width="200px" BackColor="#FFFFCC" BorderStyle="None" Height="30px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredAddressValidator" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:CustomValidator ID="MinLengthAddressValidator" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address must be at least 2 characters long" ValidateValue="ValidateMinLength" ForeColor="Red"></asp:CustomValidator>
<asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address must be at least 2 letters long" ForeColor="Red" ClientValidationFunction="validateAddressLength"></asp:CustomValidator>
 
          
<label for="City">
<br />
            City:</label><asp:TextBox ID="txtCity" runat="server" Width="200px" BackColor="#FFFFCC" BorderStyle="None" Height="30px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredCityValidator" runat="server" ControlToValidate="txtCity" ErrorMessage="City is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:CustomValidator ID="MinLengthCityValidator" runat="server" ControlToValidate="txtCity" ErrorMessage="City must be at least 2 characters long" ValidateValue="ValidateMinLength" ForeColor="Red"></asp:CustomValidator>
<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCity" ErrorMessage="City must be at least 2 letters long" ForeColor="Red" ClientValidationFunction="validateCityLength"></asp:CustomValidator>
 
 
          <label for="ZipCode">
<br />
            Zip Code:</label>
<asp:TextBox ID="txtZipCode" runat="server" Width="200px" BackColor="#FFFFCC" BorderStyle="None" Height="30px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Zip Code is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="regexZipCode" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Zip Code must be 5 digits" ValidationExpression="\d{5}" ForeColor="Red"></asp:RegularExpressionValidator>
<label for="Phone">
<br />
            Phone:</label>
<asp:TextBox ID="txtPhone" runat="server" Width="200px" BackColor="#FFFFCC" BorderStyle="None" Height="30px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="regexPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="format (XX-XXXXXXX or XXX-XXXXXXX)" ValidationExpression="\d{10}" ForeColor="Red"></asp:RegularExpressionValidator>

<label for="Email">
<br />
            E-Mail:</label>&nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="200px" BackColor="#FFFFCC" BorderStyle="None" Height="30px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format (xyz@xyz.xyz)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+" ForeColor="Red"></asp:RegularExpressionValidator>
<br />

<br />
<asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" />
 
        </div>
</form>
</body>
<script>
        function validateCityLength(source, args) {
            var cityInput = document.getElementById('<%= txtCity.ClientID %>').value;
        if (cityInput.length >= 2) {
            args.IsValid = true;
        } else {
            args.IsValid = false;
        }
        }
 
        function validateAddressLength(source, args) {
            var addressInput = document.getElementById('<%= txtAddress.ClientID %>').value;
            if (addressInput.length >= 2) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
</script>
</html>