<%@ Page Language="C#" MasterPageFile="~/MasterPages/TabDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="SE301000.aspx.cs" Inherits="Page_SE301000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/TabDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="Beta.Segmentation.CustomerSegmentation"
        PrimaryView="TrainingInput"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXTab ID="tab" runat="server" DataSourceID="ds" Style="z-index: 100" 
		Width="100%" Height="550px" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="Training">
				<Template>
					<px:PXFormView Width="100%" Height="1000px" runat="server" ID="CstFormView1" DataMember="TrainingInput" >
						<Template>
							<px:PXNumberEdit runat="server" ID="CstPXNumberEdit2" DataField="GroupsQuant" ></px:PXNumberEdit>
							<px:PXImage Height="800px" runat="server" ID="pxImg" ImageUrl="~/Icons/img.png" ></px:PXImage>
                        </Template>
					
						<AutoSize Enabled="True" ></AutoSize></px:PXFormView>
				</Template>
			</px:PXTabItem>
			<px:PXTabItem Text="Testing">
				<Template>
					<px:PXFormView Width="100%" Height="1000px" runat="server" ID="CstFormView1" DataMember="TrainingInput">
						<Template>
                            <px:PXImage Height="800px" runat="server" ID="pxImgRes" ImageUrl="~/Icons/imgRes.png" ></px:PXImage>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
		</Items>
	</px:PXTab>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="DetailsView">
			    <Columns>
				<px:PXGridColumn DataField="Z" Width="100" />
				<px:PXGridColumn DataField="Y" Width="100" />
				<px:PXGridColumn DataField="X" Width="100" /></Columns>
			
				<RowTemplate>
					<px:PXNumberEdit runat="server" ID="CstPXNumberEdit6" DataField="X" ></px:PXNumberEdit>
					<px:PXNumberEdit runat="server" ID="CstPXNumberEdit7" DataField="Y" ></px:PXNumberEdit>
					<px:PXNumberEdit runat="server" ID="CstPXNumberEdit8" DataField="Z" ></px:PXNumberEdit></RowTemplate></px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
		<ActionBar >
		</ActionBar>
	</px:PXGrid>
</asp:Content>