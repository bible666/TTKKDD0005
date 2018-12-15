<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="PoomseWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" runat="server">
    โปรดเลือกมุม ที่ต้องการดำเนินการ
    <div>
        <table>
            <tr>
                <td>
                    <asp:RadioButton ID="rdb1" GroupName="Judge" runat="server" Checked="True" Text="Judge 1" />
                </td>
                <td>
                    <asp:RadioButton ID="rdb2" GroupName="Judge" runat="server" Text="Judge 2" />
                </td>
                <td>
                    <asp:RadioButton ID="rdb3" GroupName="Judge" runat="server" Text="Judge 3" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rdb4" GroupName="Judge" runat="server" Text="Judge 4" />
                </td>
                <td>
                    <asp:RadioButton ID="rdb5" GroupName="Judge" runat="server" Text="Judge 5" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rdb6" GroupName="Judge" runat="server" Text="Judge 6" />
                </td>
                <td>
                    <asp:RadioButton ID="rdb7" GroupName="Judge" runat="server" Text="Judge 7" />
                </td>
            </tr>
        </table>
    </div>
	<br/>
	 โปรดเลือกประเภทคะแนน
    <div>
        <table>
            <tr>
                <td>
                    <asp:RadioButton ID="rdbType1" GroupName="ScoreType" runat="server" Checked="True" Text="Acc : 4.00          Pre : 6.00" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rdbType2" GroupName="ScoreType" runat="server"  Text="Acc : 6.00          Pre : 4.00" />
                </td>
            </tr>
        </table>
    </div>
    
    ผู้เข้าแข่งขัน 1
    <div>
        <table>
            <tr>
                <td>
                    รหัสผู้แข่งขัน 
                    <asp:TextBox ID="AutherId1" runat="server" Width="70px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ชื่อผู้แข่งขัน 
                    <asp:TextBox ID="AutherName1" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    
    ผู้เข้าแข่งขัน 2
    <div>
        <table>
            <tr>
                <td>
                    รหัสผู้แข่งขัน 
                    <asp:TextBox ID="AutherId2" runat="server" Width="70px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ชื่อผู้แข่งขัน 
                    <asp:TextBox ID="AutherName2" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
	
    &nbsp;<asp:Button ID="Button1" runat="server" Text="OK" />
    </form>
</body>
</html>

