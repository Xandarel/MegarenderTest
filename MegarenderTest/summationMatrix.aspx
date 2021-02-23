<%@ Page Title="summationMatrix" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="summationMatrix.aspx.cs" Inherits="MegarenderTest.summationMatrix" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="padding: inherit; margin: auto; background-color: #C0C0C0; vertical-align: top; display: inline-block;" id="matrixA" class="matrixA">
            <p>Матрица A</p>
            <p>
                <asp:TextBox ID="Matrix1_1" runat="server"></asp:TextBox>
                <asp:TextBox ID="Matrix1_2" runat="server"></asp:TextBox>
                <asp:TextBox ID="Matrix1_3" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="Matrix1_4" runat="server"></asp:TextBox>
                <asp:TextBox ID="Matrix1_5" runat="server"></asp:TextBox>
                <asp:TextBox ID="Matrix1_6" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="Matrix1_7" runat="server"></asp:TextBox>
                <asp:TextBox ID="Matrix1_8" runat="server"></asp:TextBox>
                <asp:TextBox ID="Matrix1_9" runat="server"></asp:TextBox>
            </p>
            <div style= "background-color: #99FF66" id="MatrixB">
                <p>Матрица B</p>
                <p>
                    <asp:TextBox ID="Matrix2_1" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Matrix2_2" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Matrix2_3" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="Matrix2_4" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Matrix2_5" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Matrix2_6" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="Matrix2_7" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Matrix2_8" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Matrix2_9" runat="server"></asp:TextBox>
                </p>
            </div>
        </div>
        <p>
            <asp:Button ID="calculate" runat="server" Text="=" Width="50px" OnClick="calculate_Click"/>
        </p>
        <div id="result">
            <p>Результат</p>
            <p>
                <asp:TextBox ID="ResultMatrix1" runat="server"></asp:TextBox>
                <asp:TextBox ID="ResultMatrix2" runat="server"></asp:TextBox>
                <asp:TextBox ID="ResultMatrix3" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="ResultMatrix4" runat="server"></asp:TextBox>
                <asp:TextBox ID="ResultMatrix5" runat="server"></asp:TextBox>
                <asp:TextBox ID="ResultMatrix6" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="ResultMatrix7" runat="server"></asp:TextBox>
                <asp:TextBox ID="ResultMatrix8" runat="server"></asp:TextBox>
                <asp:TextBox ID="ResultMatrix9" runat="server"></asp:TextBox>
            </p>
        </div>
        <p><a href="Default.aspx">Home</a></p>
    </div>
</asp:Content>
