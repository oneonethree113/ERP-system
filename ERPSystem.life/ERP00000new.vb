Public Class ERP00000new
    Inherits System.Windows.Forms.Form

    Dim SkipExitMsg As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lbMenu As System.Windows.Forms.ListBox
    Friend WithEvents msMenuERP As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuBarSetup As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents smiReLegin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbmenu2 As System.Windows.Forms.ListBox
    Friend WithEvents smiSYS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYS01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYS02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYS03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYS04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator51 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiSYM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM06 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM08 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM09 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM16 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM17 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM23 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM26 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM28 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM29 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator52 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiSYM33 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator53 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiIMM04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMX07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR35 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator54 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiIMX01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMM13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR34 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator55 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiIMX05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMM12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR18 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMM15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator56 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiIMG01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMG02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiCUS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiCUM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiCUM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiCUM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiVN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiVNM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator57 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem338 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem339 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator58 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem340 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQUM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQUA01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQUM04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator59 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiQUR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator60 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiQUX01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQUR03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator61 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem348 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem349 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiRIR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSAM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSAM04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSAM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSAM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSAM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSAM05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator62 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiSAR05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSAR06 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSAR07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiTO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiTOM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiTOM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiTOM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiTOM04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiTOM05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSCM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSCM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSCM04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSCM07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSCM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSCM06 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator63 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiSCR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSCR03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR09 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR24 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR25 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR26 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR29 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR30 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR31 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR36 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR32 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPOM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPOM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiBOM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator64 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiPOR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPOR03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPOR05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPOR07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiBOR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator65 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiPOM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSHP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSHM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM30 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator66 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiSHM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator67 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiSYM36 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSHM07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator68 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiINR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPKR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSHR10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator69 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiMSR09 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR27 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR36 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM31 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator70 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiPGM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator71 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiPGM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGX01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator72 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiPGM05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGM04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGM08 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator73 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiPGM09 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator74 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents msiPGM06 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGM11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGM12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiPGM13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator75 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents msiPGM07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem421 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM37 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM38 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator76 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiCLM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator77 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiCLR04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiCLR05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator78 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiCLR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiACR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiPCM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiSYM32 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator79 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiACR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator80 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiSMR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSMR02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiBFR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiBJR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiFTY01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiFTY04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem438 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator81 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiMPO01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPO02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPO03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator82 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiMPR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPR02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPR03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPR04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPR05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMPR06 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator83 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiMIM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMIM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiQC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM39 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSYM40 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator84 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiQCM01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQCM02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQCM03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator85 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiQCM04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQCM09 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator86 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiQCM05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiQCM06 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator87 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiQCM07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem465 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem466 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIAR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR17 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR32 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR23 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR27 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR21 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiIMR22 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiINR14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem476 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR22 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR31 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR33 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem483 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiMSR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiMSR04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiMSR12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiMSR05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiMSR35 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem489 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msiIMR19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiINR11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiSCR02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiBSP04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem495 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiINR04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiINR10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiINR132 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiINR13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiINR12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem501 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiMSR08 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem503 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR03 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR04 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR05 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR06 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR07 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR08 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR09 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiDYR10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator88 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smiCOR01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnOldEnableStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnOldVisibleStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNewVisibleStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ts0 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DocumentDiagramToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ts1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LeftMenuToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ts2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RightMenuToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents t3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TopMenuBarMainOnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnToLong As System.Windows.Forms.Button
    Friend WithEvents btnToShort As System.Windows.Forms.Button
    Friend WithEvents btnNewMenuEnableStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TopMenuBarERPOnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ERP00000new))
        Me.lbMenu = New System.Windows.Forms.ListBox
        Me.msMenuERP = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiReLegin = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem22 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYS = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYS01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYS02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYS03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYS04 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator51 = New System.Windows.Forms.ToolStripSeparator
        Me.smiSYM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM06 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM07 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM08 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM09 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM10 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM11 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM12 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM13 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM14 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM15 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM16 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM17 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM23 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM26 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM28 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM29 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator52 = New System.Windows.Forms.ToolStripSeparator
        Me.smiSYM33 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMM = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator53 = New System.Windows.Forms.ToolStripSeparator
        Me.smiIMM04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMX07 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR35 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator54 = New System.Windows.Forms.ToolStripSeparator
        Me.smiIMX01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMM13 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR34 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator55 = New System.Windows.Forms.ToolStripSeparator
        Me.smiIMX05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMM12 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR18 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMM15 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator56 = New System.Windows.Forms.ToolStripSeparator
        Me.smiIMG01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMG02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiCUS = New System.Windows.Forms.ToolStripMenuItem
        Me.smiCUM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiCUM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiCUM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiVN = New System.Windows.Forms.ToolStripMenuItem
        Me.smiVNM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator57 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem338 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem339 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator58 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem340 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQU = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQUM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQUA01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQUM04 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator59 = New System.Windows.Forms.ToolStripSeparator
        Me.smiQUR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator60 = New System.Windows.Forms.ToolStripSeparator
        Me.smiQUX01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQUR03 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator61 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem348 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem349 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiRIR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSAM = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSAM04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSAM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSAM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSAM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSAM05 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator62 = New System.Windows.Forms.ToolStripSeparator
        Me.smiSAR05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSAR06 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSAR07 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiTO = New System.Windows.Forms.ToolStripMenuItem
        Me.smiTOM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiTOM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiTOM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiTOM04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiTOM05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSCM = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSCM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSCM04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSCM07 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSCM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSCM06 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator63 = New System.Windows.Forms.ToolStripSeparator
        Me.smiSCR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSCR03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR09 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR24 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR25 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR26 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR29 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR30 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR31 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR36 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR32 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPO = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPOM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPOM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiBOM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator64 = New System.Windows.Forms.ToolStripSeparator
        Me.smiPOR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPOR03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPOR05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPOR07 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiBOR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator65 = New System.Windows.Forms.ToolStripSeparator
        Me.smiPOM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSHP = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSHM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM30 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator66 = New System.Windows.Forms.ToolStripSeparator
        Me.smiSHM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator67 = New System.Windows.Forms.ToolStripSeparator
        Me.smiSYM36 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSHM07 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator68 = New System.Windows.Forms.ToolStripSeparator
        Me.smiINR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPKR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSHR10 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator69 = New System.Windows.Forms.ToolStripSeparator
        Me.smiMSR09 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR27 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR36 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGM = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM31 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator70 = New System.Windows.Forms.ToolStripSeparator
        Me.smiPGM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator71 = New System.Windows.Forms.ToolStripSeparator
        Me.smiPGM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGX01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator72 = New System.Windows.Forms.ToolStripSeparator
        Me.smiPGM05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGM04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGM08 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator73 = New System.Windows.Forms.ToolStripSeparator
        Me.smiPGM09 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator74 = New System.Windows.Forms.ToolStripSeparator
        Me.msiPGM06 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGM11 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGM12 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiPGM13 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator75 = New System.Windows.Forms.ToolStripSeparator
        Me.msiPGM07 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem421 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM37 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM38 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator76 = New System.Windows.Forms.ToolStripSeparator
        Me.smiCLM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator77 = New System.Windows.Forms.ToolStripSeparator
        Me.smiCLR04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiCLR05 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator78 = New System.Windows.Forms.ToolStripSeparator
        Me.smiCLR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiACR = New System.Windows.Forms.ToolStripMenuItem
        Me.msiPCM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiSYM32 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator79 = New System.Windows.Forms.ToolStripSeparator
        Me.smiACR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator80 = New System.Windows.Forms.ToolStripSeparator
        Me.smiSMR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSMR02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiBFR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiBJR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiFTY01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiFTY04 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem438 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator81 = New System.Windows.Forms.ToolStripSeparator
        Me.smiMPO01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPO02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPO03 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator82 = New System.Windows.Forms.ToolStripSeparator
        Me.smiMPR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPR02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPR03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPR04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPR05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMPR06 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator83 = New System.Windows.Forms.ToolStripSeparator
        Me.smiMIM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMIM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM20 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiQC = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM39 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSYM40 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator84 = New System.Windows.Forms.ToolStripSeparator
        Me.smiQCM01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQCM02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQCM03 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator85 = New System.Windows.Forms.ToolStripSeparator
        Me.smiQCM04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQCM09 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator86 = New System.Windows.Forms.ToolStripSeparator
        Me.smiQCM05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiQCM06 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator87 = New System.Windows.Forms.ToolStripSeparator
        Me.smiQCM07 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem465 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem466 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIAR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR17 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR32 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR13 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR23 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR27 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR21 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiIMR22 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.smiINR14 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem476 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR19 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR20 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR22 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR31 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR33 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem483 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiMSR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiMSR04 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiMSR12 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiMSR05 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiMSR35 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem489 = New System.Windows.Forms.ToolStripMenuItem
        Me.msiIMR19 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiINR11 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiSCR02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR07 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiBSP04 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem495 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiINR04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiINR10 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiINR132 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiINR13 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiINR12 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem501 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiMSR08 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem503 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR02 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR03 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR04 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR05 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR06 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR07 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR08 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR09 = New System.Windows.Forms.ToolStripMenuItem
        Me.smiDYR10 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator88 = New System.Windows.Forms.ToolStripSeparator
        Me.smiCOR01 = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.MenuBarSetup = New System.Windows.Forms.ToolStripDropDownButton
        Me.TopMenuBarMainOnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TopMenuBarERPOnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnOldEnableStyle = New System.Windows.Forms.ToolStripMenuItem
        Me.btnOldVisibleStyle = New System.Windows.Forms.ToolStripMenuItem
        Me.btnNewMenuEnableStyle = New System.Windows.Forms.ToolStripMenuItem
        Me.btnNewVisibleStyle = New System.Windows.Forms.ToolStripMenuItem
        Me.ts0 = New System.Windows.Forms.ToolStripStatusLabel
        Me.DocumentDiagramToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ts1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LeftMenuToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ts2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.RightMenuToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.t3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbmenu2 = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.btnToLong = New System.Windows.Forms.Button
        Me.btnToShort = New System.Windows.Forms.Button
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox
        Me.msMenuERP.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbMenu
        '
        Me.lbMenu.ItemHeight = 12
        Me.lbMenu.Location = New System.Drawing.Point(417, 37)
        Me.lbMenu.Name = "lbMenu"
        Me.lbMenu.Size = New System.Drawing.Size(96, 4)
        Me.lbMenu.TabIndex = 4
        Me.lbMenu.Visible = False
        '
        'msMenuERP
        '
        Me.msMenuERP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.ToolStripTextBox2, Me.smiSYS, Me.smiIMM, Me.smiCUS, Me.smiVN, Me.smiQU, Me.smiSAM, Me.smiTO, Me.smiSCM, Me.smiPO, Me.smiSHP, Me.smiPGM, Me.ToolStripMenuItem421, Me.smiACR, Me.smiBFR01, Me.ToolStripMenuItem438, Me.msiQC, Me.ToolStripMenuItem465, Me.WindowToolStripMenuItem})
        Me.msMenuERP.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.msMenuERP.Location = New System.Drawing.Point(0, 0)
        Me.msMenuERP.MdiWindowListItem = Me.WindowToolStripMenuItem
        Me.msMenuERP.Name = "msMenuERP"
        Me.msMenuERP.Size = New System.Drawing.Size(992, 42)
        Me.msMenuERP.TabIndex = 6
        Me.msMenuERP.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiReLegin, Me.ToolStripMenuItem22, Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(38, 19)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'smiReLegin
        '
        Me.smiReLegin.Name = "smiReLegin"
        Me.smiReLegin.Size = New System.Drawing.Size(126, 22)
        Me.smiReLegin.Text = "Re-Login"
        '
        'ToolStripMenuItem22
        '
        Me.ToolStripMenuItem22.Name = "ToolStripMenuItem22"
        Me.ToolStripMenuItem22.Size = New System.Drawing.Size(123, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'smiSYS
        '
        Me.smiSYS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiSYS01, Me.smiSYS02, Me.smiSYS03, Me.smiSYS04, Me.ToolStripSeparator51, Me.smiSYM01, Me.smiSYM02, Me.smiSYM03, Me.smiSYM04, Me.smiSYM05, Me.smiSYM06, Me.smiSYM07, Me.smiSYM08, Me.smiSYM09, Me.smiSYM10, Me.smiSYM11, Me.smiSYM12, Me.smiSYM13, Me.smiSYM14, Me.smiSYM15, Me.smiSYM16, Me.smiSYM17, Me.smiSYM23, Me.smiSYM26, Me.smiSYM28, Me.smiSYM29, Me.ToolStripSeparator52, Me.smiSYM33})
        Me.smiSYS.Name = "smiSYS"
        Me.smiSYS.Size = New System.Drawing.Size(59, 19)
        Me.smiSYS.Text = "System"
        '
        'smiSYS01
        '
        Me.smiSYS01.Name = "smiSYS01"
        Me.smiSYS01.Size = New System.Drawing.Size(310, 22)
        Me.smiSYS01.Text = "SYS01 - User Group"
        '
        'smiSYS02
        '
        Me.smiSYS02.Name = "smiSYS02"
        Me.smiSYS02.Size = New System.Drawing.Size(310, 22)
        Me.smiSYS02.Text = "SYS02 - User Profile"
        '
        'smiSYS03
        '
        Me.smiSYS03.Name = "smiSYS03"
        Me.smiSYS03.Size = New System.Drawing.Size(310, 22)
        Me.smiSYS03.Text = "SYS03 - User Function"
        '
        'smiSYS04
        '
        Me.smiSYS04.Name = "smiSYS04"
        Me.smiSYS04.Size = New System.Drawing.Size(310, 22)
        Me.smiSYS04.Text = "SYS04 - User Authorization"
        '
        'ToolStripSeparator51
        '
        Me.ToolStripSeparator51.Name = "ToolStripSeparator51"
        Me.ToolStripSeparator51.Size = New System.Drawing.Size(307, 6)
        '
        'smiSYM01
        '
        Me.smiSYM01.Name = "smiSYM01"
        Me.smiSYM01.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM01.Text = "SYM01 - Company"
        '
        'smiSYM02
        '
        Me.smiSYM02.Name = "smiSYM02"
        Me.smiSYM02.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM02.Text = "SYM02 - System Document Control"
        '
        'smiSYM03
        '
        Me.smiSYM03.Name = "smiSYM03"
        Me.smiSYM03.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM03.Text = "SYM03 - Color"
        '
        'smiSYM04
        '
        Me.smiSYM04.Name = "smiSYM04"
        Me.smiSYM04.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM04.Text = "SYM04 - Product Line"
        '
        'smiSYM05
        '
        Me.smiSYM05.Name = "smiSYM05"
        Me.smiSYM05.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM05.Text = "SYM05 - Category"
        '
        'smiSYM06
        '
        Me.smiSYM06.Name = "smiSYM06"
        Me.smiSYM06.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM06.Text = "SYM06 - Category Relation"
        '
        'smiSYM07
        '
        Me.smiSYM07.Name = "smiSYM07"
        Me.smiSYM07.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM07.Text = "SYM07 - Harmonized Code"
        '
        'smiSYM08
        '
        Me.smiSYM08.Name = "smiSYM08"
        Me.smiSYM08.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM08.Text = "SYM08 - Setup"
        '
        'smiSYM09
        '
        Me.smiSYM09.Name = "smiSYM09"
        Me.smiSYM09.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM09.Text = "SYM09 - Conversion Factor"
        '
        'smiSYM10
        '
        Me.smiSYM10.Name = "smiSYM10"
        Me.smiSYM10.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM10.Text = "SYM10 - Sales Representative"
        '
        'smiSYM11
        '
        Me.smiSYM11.Name = "smiSYM11"
        Me.smiSYM11.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM11.Text = "SYM11 - MOQ / MOA and Commission"
        '
        'smiSYM12
        '
        Me.smiSYM12.Name = "smiSYM12"
        Me.smiSYM12.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM12.Text = "SYM12 - Agent"
        '
        'smiSYM13
        '
        Me.smiSYM13.Name = "smiSYM13"
        Me.smiSYM13.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM13.Text = "SYM13 - Discount/Premium"
        '
        'smiSYM14
        '
        Me.smiSYM14.Name = "smiSYM14"
        Me.smiSYM14.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM14.Text = "SYM14 - Sample Terms"
        '
        'smiSYM15
        '
        Me.smiSYM15.Name = "smiSYM15"
        Me.smiSYM15.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM15.Text = "SYM15 - External Vendor Price Formula"
        '
        'smiSYM16
        '
        Me.smiSYM16.Name = "smiSYM16"
        Me.smiSYM16.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM16.Text = "SYM16 - Internal Vendor Price Formula"
        '
        'smiSYM17
        '
        Me.smiSYM17.Name = "smiSYM17"
        Me.smiSYM17.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM17.Text = "SYM17 - Formula Maintenance"
        '
        'smiSYM23
        '
        Me.smiSYM23.Name = "smiSYM23"
        Me.smiSYM23.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM23.Text = "SYM23 - ABCD Cost Setup"
        '
        'smiSYM26
        '
        Me.smiSYM26.Name = "smiSYM26"
        Me.smiSYM26.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM26.Text = "SYM26 - Currency Maintenance"
        '
        'smiSYM28
        '
        Me.smiSYM28.Name = "smiSYM28"
        Me.smiSYM28.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM28.Text = "SYM28 - Sales Team Maintenance"
        '
        'smiSYM29
        '
        Me.smiSYM29.Name = "smiSYM29"
        Me.smiSYM29.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM29.Text = "SYM29 - SAP Unit of Measure Mapping "
        '
        'ToolStripSeparator52
        '
        Me.ToolStripSeparator52.Name = "ToolStripSeparator52"
        Me.ToolStripSeparator52.Size = New System.Drawing.Size(307, 6)
        '
        'smiSYM33
        '
        Me.smiSYM33.Name = "smiSYM33"
        Me.smiSYM33.Size = New System.Drawing.Size(310, 22)
        Me.smiSYM33.Text = "SYM33 - Shipping Charges Formula Setup"
        '
        'smiIMM
        '
        Me.smiIMM.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiIMM01, Me.ToolStripSeparator53, Me.smiIMM04, Me.smiIMX07, Me.smiIMR35, Me.ToolStripSeparator54, Me.smiIMX01, Me.smiIMM02, Me.smiIMM13, Me.smiIMR04, Me.smiIMR05, Me.smiIMR34, Me.ToolStripSeparator55, Me.smiIMX05, Me.smiIMM12, Me.smiIMR18, Me.smiIMM15, Me.ToolStripSeparator56, Me.smiIMG01, Me.smiIMG02})
        Me.smiIMM.Name = "smiIMM"
        Me.smiIMM.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.smiIMM.Size = New System.Drawing.Size(44, 19)
        Me.smiIMM.Text = "Item"
        '
        'smiIMM01
        '
        Me.smiIMM01.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.smiIMM01.Name = "smiIMM01"
        Me.smiIMM01.Size = New System.Drawing.Size(505, 22)
        Me.smiIMM01.Text = "IMM01 - Item Master Maintenance"
        '
        'ToolStripSeparator53
        '
        Me.ToolStripSeparator53.Name = "ToolStripSeparator53"
        Me.ToolStripSeparator53.Size = New System.Drawing.Size(502, 6)
        '
        'smiIMM04
        '
        Me.smiIMM04.Name = "smiIMM04"
        Me.smiIMM04.Size = New System.Drawing.Size(505, 22)
        Me.smiIMM04.Text = "IMM04 - Hold / Release Item Status"
        '
        'smiIMX07
        '
        Me.smiIMX07.Name = "smiIMX07"
        Me.smiIMX07.Size = New System.Drawing.Size(505, 22)
        Me.smiIMX07.Text = "IMX07 - Temp Item and Real Item Matching Excel File Upload"
        '
        'smiIMR35
        '
        Me.smiIMR35.Name = "smiIMR35"
        Me.smiIMR35.Size = New System.Drawing.Size(505, 22)
        Me.smiIMR35.Text = "IMR35  - Item Master Price Change Report"
        '
        'ToolStripSeparator54
        '
        Me.ToolStripSeparator54.Name = "ToolStripSeparator54"
        Me.ToolStripSeparator54.Size = New System.Drawing.Size(502, 6)
        '
        'smiIMX01
        '
        Me.smiIMX01.Name = "smiIMX01"
        Me.smiIMX01.Size = New System.Drawing.Size(505, 22)
        Me.smiIMX01.Text = "IMX01 - Item Excel File Upload (Interal && Joint Venture Item)"
        '
        'smiIMM02
        '
        Me.smiIMM02.Name = "smiIMM02"
        Me.smiIMM02.Size = New System.Drawing.Size(505, 22)
        Me.smiIMM02.Text = "IMM02 - Item Master Approval && Rejection (Internal && Joint Venture Item)"
        '
        'smiIMM13
        '
        Me.smiIMM13.Name = "smiIMM13"
        Me.smiIMM13.Size = New System.Drawing.Size(505, 22)
        Me.smiIMM13.Text = "IMM13 - Item Master Invalid Item Reactivation (Internal && Joint Venture Item)"
        '
        'smiIMR04
        '
        Me.smiIMR04.Name = "smiIMR04"
        Me.smiIMR04.Size = New System.Drawing.Size(505, 22)
        Me.smiIMR04.Text = "IMR04 - Item Validation Report (Internal && Joint Venture Item)"
        '
        'smiIMR05
        '
        Me.smiIMR05.Name = "smiIMR05"
        Me.smiIMR05.Size = New System.Drawing.Size(505, 22)
        Me.smiIMR05.Text = "IMR05 - Excel File Search Report (Internal && Joint Venture Item)"
        '
        'smiIMR34
        '
        Me.smiIMR34.Name = "smiIMR34"
        Me.smiIMR34.Size = New System.Drawing.Size(505, 22)
        Me.smiIMR34.Text = "IMR34 - Item Master Report Export (Internal && Joint Venture Item)"
        '
        'ToolStripSeparator55
        '
        Me.ToolStripSeparator55.Name = "ToolStripSeparator55"
        Me.ToolStripSeparator55.Size = New System.Drawing.Size(502, 6)
        '
        'smiIMX05
        '
        Me.smiIMX05.Name = "smiIMX05"
        Me.smiIMX05.Size = New System.Drawing.Size(505, 22)
        Me.smiIMX05.Text = "IMX05 - Item Excel File Upload (External Item)"
        '
        'smiIMM12
        '
        Me.smiIMM12.Name = "smiIMM12"
        Me.smiIMM12.Size = New System.Drawing.Size(505, 22)
        Me.smiIMM12.Text = "IMM12 - Item Master Approval && Rejection (External Item)"
        '
        'smiIMR18
        '
        Me.smiIMR18.Name = "smiIMR18"
        Me.smiIMR18.Size = New System.Drawing.Size(505, 22)
        Me.smiIMR18.Text = "IMR18 - Item Validation Report (External Item)"
        '
        'smiIMM15
        '
        Me.smiIMM15.Name = "smiIMM15"
        Me.smiIMM15.Size = New System.Drawing.Size(505, 22)
        Me.smiIMM15.Text = "IMM15 - Item Master Data Export (External Item)"
        '
        'ToolStripSeparator56
        '
        Me.ToolStripSeparator56.Name = "ToolStripSeparator56"
        Me.ToolStripSeparator56.Size = New System.Drawing.Size(502, 6)
        '
        'smiIMG01
        '
        Me.smiIMG01.Name = "smiIMG01"
        Me.smiIMG01.Size = New System.Drawing.Size(505, 22)
        Me.smiIMG01.Text = "IMG01 - Item Master Image Upload"
        '
        'smiIMG02
        '
        Me.smiIMG02.Name = "smiIMG02"
        Me.smiIMG02.Size = New System.Drawing.Size(505, 22)
        Me.smiIMG02.Text = "IMG02 - Item Master Image Upload (External Item)"
        '
        'smiCUS
        '
        Me.smiCUS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiCUM01, Me.smiCUM02, Me.smiCUM03})
        Me.smiCUS.Name = "smiCUS"
        Me.smiCUS.Size = New System.Drawing.Size(73, 19)
        Me.smiCUS.Text = "Customer"
        '
        'smiCUM01
        '
        Me.smiCUM01.Name = "smiCUM01"
        Me.smiCUM01.Size = New System.Drawing.Size(301, 22)
        Me.smiCUM01.Text = "CUM01 - Customer Master Maintenance"
        '
        'smiCUM02
        '
        Me.smiCUM02.Name = "smiCUM02"
        Me.smiCUM02.Size = New System.Drawing.Size(301, 22)
        Me.smiCUM02.Text = "CUM02 - Customer Item History (Old)"
        '
        'smiCUM03
        '
        Me.smiCUM03.Name = "smiCUM03"
        Me.smiCUM03.Size = New System.Drawing.Size(301, 22)
        Me.smiCUM03.Text = "CUM03 - Customer Item History (New)"
        '
        'smiVN
        '
        Me.smiVN.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiVNM01, Me.ToolStripSeparator57, Me.ToolStripMenuItem338, Me.ToolStripMenuItem339, Me.ToolStripSeparator58, Me.ToolStripMenuItem340})
        Me.smiVN.Name = "smiVN"
        Me.smiVN.Size = New System.Drawing.Size(61, 19)
        Me.smiVN.Text = "Vendor"
        '
        'smiVNM01
        '
        Me.smiVNM01.Name = "smiVNM01"
        Me.smiVNM01.Size = New System.Drawing.Size(310, 22)
        Me.smiVNM01.Text = "VNM01 - Vendor Master Maintenance"
        '
        'ToolStripSeparator57
        '
        Me.ToolStripSeparator57.Name = "ToolStripSeparator57"
        Me.ToolStripSeparator57.Size = New System.Drawing.Size(307, 6)
        '
        'ToolStripMenuItem338
        '
        Me.ToolStripMenuItem338.Name = "ToolStripMenuItem338"
        Me.ToolStripMenuItem338.Size = New System.Drawing.Size(310, 22)
        Me.ToolStripMenuItem338.Text = "SYM34 - Trading Term Maintenance "
        '
        'ToolStripMenuItem339
        '
        Me.ToolStripMenuItem339.Name = "ToolStripMenuItem339"
        Me.ToolStripMenuItem339.Size = New System.Drawing.Size(310, 22)
        Me.ToolStripMenuItem339.Text = "SYM35 - Vendor Trading Term Setup"
        '
        'ToolStripSeparator58
        '
        Me.ToolStripSeparator58.Name = "ToolStripSeparator58"
        Me.ToolStripSeparator58.Size = New System.Drawing.Size(307, 6)
        '
        'ToolStripMenuItem340
        '
        Me.ToolStripMenuItem340.Name = "ToolStripMenuItem340"
        Me.ToolStripMenuItem340.Size = New System.Drawing.Size(310, 22)
        Me.ToolStripMenuItem340.Text = "SYR01 - Vendor Trading Terms List Report"
        '
        'smiQU
        '
        Me.smiQU.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiQUM01, Me.smiQUA01, Me.smiQUM04, Me.ToolStripSeparator59, Me.smiQUR01, Me.ToolStripSeparator60, Me.smiQUX01, Me.smiQUR03, Me.ToolStripSeparator61, Me.ToolStripMenuItem348, Me.ToolStripMenuItem349, Me.smiRIR01})
        Me.smiQU.Name = "smiQU"
        Me.smiQU.Size = New System.Drawing.Size(77, 19)
        Me.smiQU.Text = "Quotation"
        '
        'smiQUM01
        '
        Me.smiQUM01.Name = "smiQUM01"
        Me.smiQUM01.Size = New System.Drawing.Size(422, 22)
        Me.smiQUM01.Text = "QUM01 - Quotation Maintenance"
        '
        'smiQUA01
        '
        Me.smiQUA01.Name = "smiQUA01"
        Me.smiQUA01.Size = New System.Drawing.Size(422, 22)
        Me.smiQUA01.Text = "QUA01 - Quotation Apps Approval / Reject"
        '
        'smiQUM04
        '
        Me.smiQUM04.Name = "smiQUM04"
        Me.smiQUM04.Size = New System.Drawing.Size(422, 22)
        Me.smiQUM04.Text = "QUM04 - PDA Quotation Approve / Reject"
        '
        'ToolStripSeparator59
        '
        Me.ToolStripSeparator59.Name = "ToolStripSeparator59"
        Me.ToolStripSeparator59.Size = New System.Drawing.Size(419, 6)
        '
        'smiQUR01
        '
        Me.smiQUR01.Name = "smiQUR01"
        Me.smiQUR01.Size = New System.Drawing.Size(422, 22)
        Me.smiQUR01.Text = "QUR01 - Print Quotation"
        '
        'ToolStripSeparator60
        '
        Me.ToolStripSeparator60.Name = "ToolStripSeparator60"
        Me.ToolStripSeparator60.Size = New System.Drawing.Size(419, 6)
        '
        'smiQUX01
        '
        Me.smiQUX01.Name = "smiQUX01"
        Me.smiQUX01.Size = New System.Drawing.Size(422, 22)
        Me.smiQUX01.Text = "QUX01 - Upload Quotation Excel to ERP"
        '
        'smiQUR03
        '
        Me.smiQUR03.Name = "smiQUR03"
        Me.smiQUR03.Size = New System.Drawing.Size(422, 22)
        Me.smiQUR03.Text = "QUR03 - Export Quotation to Excel"
        '
        'ToolStripSeparator61
        '
        Me.ToolStripSeparator61.Name = "ToolStripSeparator61"
        Me.ToolStripSeparator61.Size = New System.Drawing.Size(419, 6)
        '
        'ToolStripMenuItem348
        '
        Me.ToolStripMenuItem348.Name = "ToolStripMenuItem348"
        Me.ToolStripMenuItem348.Size = New System.Drawing.Size(422, 22)
        Me.ToolStripMenuItem348.Text = "IMXLSx004 - Customer Style Number"
        '
        'ToolStripMenuItem349
        '
        Me.ToolStripMenuItem349.Name = "ToolStripMenuItem349"
        Me.ToolStripMenuItem349.Size = New System.Drawing.Size(422, 22)
        Me.ToolStripMenuItem349.Text = "IMRx00010 - Item Validation Report (Customer Style Number)"
        '
        'smiRIR01
        '
        Me.smiRIR01.Name = "smiRIR01"
        Me.smiRIR01.Size = New System.Drawing.Size(422, 22)
        Me.smiRIR01.Text = "RIR01 - ReQuote Item List"
        '
        'smiSAM
        '
        Me.smiSAM.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiSAM04, Me.smiSAM01, Me.smiSAM02, Me.smiSAM03, Me.smiSAM05, Me.ToolStripSeparator62, Me.smiSAR05, Me.smiSAR06, Me.smiSAR07})
        Me.smiSAM.Name = "smiSAM"
        Me.smiSAM.Size = New System.Drawing.Size(62, 19)
        Me.smiSAM.Text = "Sample"
        '
        'smiSAM04
        '
        Me.smiSAM04.Name = "smiSAM04"
        Me.smiSAM04.Size = New System.Drawing.Size(295, 22)
        Me.smiSAM04.Text = "SAM04 - Sample Request Generation"
        '
        'smiSAM01
        '
        Me.smiSAM01.Name = "smiSAM01"
        Me.smiSAM01.Size = New System.Drawing.Size(295, 22)
        Me.smiSAM01.Text = "SAM01 - Sample Request Maintenance"
        '
        'smiSAM02
        '
        Me.smiSAM02.Name = "smiSAM02"
        Me.smiSAM02.Size = New System.Drawing.Size(295, 22)
        Me.smiSAM02.Text = "SAM02 - Sample Order Summary"
        '
        'smiSAM03
        '
        Me.smiSAM03.Name = "smiSAM03"
        Me.smiSAM03.Size = New System.Drawing.Size(295, 22)
        Me.smiSAM03.Text = "SAM03 - Sample Invoice Information"
        '
        'smiSAM05
        '
        Me.smiSAM05.Name = "smiSAM05"
        Me.smiSAM05.Size = New System.Drawing.Size(295, 22)
        Me.smiSAM05.Text = "SAM05 - Sample Invoice Generation"
        '
        'ToolStripSeparator62
        '
        Me.ToolStripSeparator62.Name = "ToolStripSeparator62"
        Me.ToolStripSeparator62.Size = New System.Drawing.Size(292, 6)
        '
        'smiSAR05
        '
        Me.smiSAR05.Name = "smiSAR05"
        Me.smiSAR05.Size = New System.Drawing.Size(295, 22)
        Me.smiSAR05.Text = "SAR05 - Sample Invoice Report"
        '
        'smiSAR06
        '
        Me.smiSAR06.Name = "smiSAR06"
        Me.smiSAR06.Size = New System.Drawing.Size(295, 22)
        Me.smiSAR06.Text = "SAR06 - Sample Request Report "
        '
        'smiSAR07
        '
        Me.smiSAR07.Name = "smiSAR07"
        Me.smiSAR07.Size = New System.Drawing.Size(295, 22)
        Me.smiSAR07.Text = "SAR07 - Packing List Report"
        '
        'smiTO
        '
        Me.smiTO.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiTOM02, Me.smiTOM01, Me.smiTOM03, Me.smiTOM04, Me.smiTOM05})
        Me.smiTO.Name = "smiTO"
        Me.smiTO.Size = New System.Drawing.Size(71, 19)
        Me.smiTO.Text = "Tentative"
        '
        'smiTOM02
        '
        Me.smiTOM02.Name = "smiTOM02"
        Me.smiTOM02.Size = New System.Drawing.Size(331, 22)
        Me.smiTOM02.Text = "TOM02 - Tentative Order Generation"
        '
        'smiTOM01
        '
        Me.smiTOM01.Name = "smiTOM01"
        Me.smiTOM01.Size = New System.Drawing.Size(331, 22)
        Me.smiTOM01.Text = "TOM01 - Tentative Order Maintenance"
        '
        'smiTOM03
        '
        Me.smiTOM03.Name = "smiTOM03"
        Me.smiTOM03.Size = New System.Drawing.Size(331, 22)
        Me.smiTOM03.Text = "TOM03 - Tenetaive Order Release/UnRelease"
        '
        'smiTOM04
        '
        Me.smiTOM04.Name = "smiTOM04"
        Me.smiTOM04.Size = New System.Drawing.Size(331, 22)
        Me.smiTOM04.Text = "TOM04 - Tentative Order History"
        '
        'smiTOM05
        '
        Me.smiTOM05.Name = "smiTOM05"
        Me.smiTOM05.Size = New System.Drawing.Size(331, 22)
        Me.smiTOM05.Text = "TOM05 - Export Tentative to Excel"
        '
        'smiSCM
        '
        Me.smiSCM.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiSCM01, Me.smiSCM04, Me.smiSCM07, Me.smiSCM03, Me.smiSCM06, Me.ToolStripSeparator63, Me.smiSCR01, Me.smiSCR03, Me.smiIMR09, Me.smiIMR24, Me.smiIMR25, Me.smiIMR26, Me.smiIMR29, Me.smiIMR30, Me.smiIMR31, Me.smiIMR36, Me.smiIMR32})
        Me.smiSCM.Name = "smiSCM"
        Me.smiSCM.Size = New System.Drawing.Size(48, 19)
        Me.smiSCM.Text = "Sales"
        '
        'smiSCM01
        '
        Me.smiSCM01.Name = "smiSCM01"
        Me.smiSCM01.Size = New System.Drawing.Size(371, 22)
        Me.smiSCM01.Text = "SCM01 - Sales Confirmation Maintenance"
        '
        'smiSCM04
        '
        Me.smiSCM04.Name = "smiSCM04"
        Me.smiSCM04.Size = New System.Drawing.Size(371, 22)
        Me.smiSCM04.Text = "SCM04 - Transport Shipmark Maintenance"
        '
        'smiSCM07
        '
        Me.smiSCM07.Name = "smiSCM07"
        Me.smiSCM07.Size = New System.Drawing.Size(371, 22)
        Me.smiSCM07.Text = "SCM07 - Release/Unrelease Sales Confirmation"
        '
        'smiSCM03
        '
        Me.smiSCM03.Name = "smiSCM03"
        Me.smiSCM03.Size = New System.Drawing.Size(371, 22)
        Me.smiSCM03.Text = "SCM03 - SC Factory Data Approval && Rejecction"
        '
        'smiSCM06
        '
        Me.smiSCM06.Name = "smiSCM06"
        Me.smiSCM06.Size = New System.Drawing.Size(371, 22)
        Me.smiSCM06.Text = "SCM06 - SC Approval && Rejection"
        '
        'ToolStripSeparator63
        '
        Me.ToolStripSeparator63.Name = "ToolStripSeparator63"
        Me.ToolStripSeparator63.Size = New System.Drawing.Size(368, 6)
        '
        'smiSCR01
        '
        Me.smiSCR01.Name = "smiSCR01"
        Me.smiSCR01.Size = New System.Drawing.Size(371, 22)
        Me.smiSCR01.Text = "SCR01 - Print Sales Confirmation Report"
        '
        'smiSCR03
        '
        Me.smiSCR03.Name = "smiSCR03"
        Me.smiSCR03.Size = New System.Drawing.Size(371, 22)
        Me.smiSCR03.Text = "SCR03 - Print Cancellation SC with BOM Item"
        '
        'smiIMR09
        '
        Me.smiIMR09.Name = "smiIMR09"
        Me.smiIMR09.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR09.Text = "IMR09 - Print Product Label List"
        '
        'smiIMR24
        '
        Me.smiIMR24.Name = "smiIMR24"
        Me.smiIMR24.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR24.Text = "IMR24 - Attachment Update History"
        '
        'smiIMR25
        '
        Me.smiIMR25.Name = "smiIMR25"
        Me.smiIMR25.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR25.Text = "IMR25 - MOQ SC Records"
        '
        'smiIMR26
        '
        Me.smiIMR26.Name = "smiIMR26"
        Me.smiIMR26.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR26.Text = "IMR26 - MOQ Outstanding Records"
        Me.smiIMR26.Visible = False
        '
        'smiIMR29
        '
        Me.smiIMR29.Name = "smiIMR29"
        Me.smiIMR29.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR29.Text = "IMR29 - Factory Approve Data Comparison Report"
        '
        'smiIMR30
        '
        Me.smiIMR30.Name = "smiIMR30"
        Me.smiIMR30.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR30.Text = "IMR30 - Factory Approve Data Batch Report"
        '
        'smiIMR31
        '
        Me.smiIMR31.Name = "smiIMR31"
        Me.smiIMR31.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR31.Text = "IMR31 - Sales Confirmation List to Excel"
        '
        'smiIMR36
        '
        Me.smiIMR36.Name = "smiIMR36"
        Me.smiIMR36.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR36.Text = "IMR36 - Sales Confirmation List to Excel (Check Data)"
        '
        'smiIMR32
        '
        Me.smiIMR32.Name = "smiIMR32"
        Me.smiIMR32.Size = New System.Drawing.Size(371, 22)
        Me.smiIMR32.Text = "IMR32 - Late Shipment Report"
        '
        'smiPO
        '
        Me.smiPO.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiPOM01, Me.smiPOM02, Me.smiBOM01, Me.ToolStripSeparator64, Me.smiPOR01, Me.smiPOR03, Me.smiPOR05, Me.smiPOR07, Me.smiBOR01, Me.ToolStripSeparator65, Me.smiPOM03})
        Me.smiPO.Name = "smiPO"
        Me.smiPO.Size = New System.Drawing.Size(69, 19)
        Me.smiPO.Text = "Purchase"
        '
        'smiPOM01
        '
        Me.smiPOM01.Name = "smiPOM01"
        Me.smiPOM01.Size = New System.Drawing.Size(346, 22)
        Me.smiPOM01.Text = "POM01 - Purchase Order Maintenance"
        '
        'smiPOM02
        '
        Me.smiPOM02.Name = "smiPOM02"
        Me.smiPOM02.Size = New System.Drawing.Size(346, 22)
        Me.smiPOM02.Text = "POM02  - Release/Unrelease Purchase Order"
        '
        'smiBOM01
        '
        Me.smiBOM01.Name = "smiBOM01"
        Me.smiBOM01.Size = New System.Drawing.Size(346, 22)
        Me.smiBOM01.Text = "BOM01 - BOM Order Maintenance"
        '
        'ToolStripSeparator64
        '
        Me.ToolStripSeparator64.Name = "ToolStripSeparator64"
        Me.ToolStripSeparator64.Size = New System.Drawing.Size(343, 6)
        '
        'smiPOR01
        '
        Me.smiPOR01.Name = "smiPOR01"
        Me.smiPOR01.Size = New System.Drawing.Size(346, 22)
        Me.smiPOR01.Text = "POR01 - Purchase Order Report"
        '
        'smiPOR03
        '
        Me.smiPOR03.Name = "smiPOR03"
        Me.smiPOR03.Size = New System.Drawing.Size(346, 22)
        Me.smiPOR03.Text = "POR03 - BOM Purchase Order"
        '
        'smiPOR05
        '
        Me.smiPOR05.Name = "smiPOR05"
        Me.smiPOR05.Size = New System.Drawing.Size(346, 22)
        Me.smiPOR05.Text = "POR05 - Print Production Note (Job Order)"
        '
        'smiPOR07
        '
        Me.smiPOR07.Name = "smiPOR07"
        Me.smiPOR07.Size = New System.Drawing.Size(346, 22)
        Me.smiPOR07.Text = "POR07 - BOM PO Report (Export to Excel)"
        '
        'smiBOR01
        '
        Me.smiBOR01.Name = "smiBOR01"
        Me.smiBOR01.Size = New System.Drawing.Size(346, 22)
        Me.smiBOR01.Text = "BOR01 - Vendor Purchase Report (BOM)"
        '
        'ToolStripSeparator65
        '
        Me.ToolStripSeparator65.Name = "ToolStripSeparator65"
        Me.ToolStripSeparator65.Size = New System.Drawing.Size(343, 6)
        '
        'smiPOM03
        '
        Me.smiPOM03.Name = "smiPOM03"
        Me.smiPOM03.Size = New System.Drawing.Size(346, 22)
        Me.smiPOM03.Text = "POM03 - Purchase Order Approval Maintenance"
        '
        'smiSHP
        '
        Me.smiSHP.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiSHM01, Me.smiSYM30, Me.ToolStripSeparator66, Me.smiSHM02, Me.ToolStripSeparator67, Me.smiSYM36, Me.smiSHM07, Me.ToolStripSeparator68, Me.smiINR01, Me.smiPKR01, Me.smiSHR10, Me.ToolStripSeparator69, Me.smiMSR09, Me.smiMSR27, Me.smiMSR36})
        Me.smiSHP.Name = "smiSHP"
        Me.smiSHP.Size = New System.Drawing.Size(70, 19)
        Me.smiSHP.Text = "Shipping"
        '
        'smiSHM01
        '
        Me.smiSHM01.Name = "smiSHM01"
        Me.smiSHM01.Size = New System.Drawing.Size(383, 22)
        Me.smiSHM01.Text = "SHM01 - Shipping Maintenance"
        '
        'smiSYM30
        '
        Me.smiSYM30.Name = "smiSYM30"
        Me.smiSYM30.Size = New System.Drawing.Size(383, 22)
        Me.smiSYM30.Text = "SYM30 - Shipping Customer Self-defined Maintenance"
        '
        'ToolStripSeparator66
        '
        Me.ToolStripSeparator66.Name = "ToolStripSeparator66"
        Me.ToolStripSeparator66.Size = New System.Drawing.Size(380, 6)
        '
        'smiSHM02
        '
        Me.smiSHM02.Name = "smiSHM02"
        Me.smiSHM02.Size = New System.Drawing.Size(383, 22)
        Me.smiSHM02.Text = "SHM02 - Credit / Debit Note Information "
        '
        'ToolStripSeparator67
        '
        Me.ToolStripSeparator67.Name = "ToolStripSeparator67"
        Me.ToolStripSeparator67.Size = New System.Drawing.Size(380, 6)
        '
        'smiSYM36
        '
        Me.smiSYM36.Name = "smiSYM36"
        Me.smiSYM36.Size = New System.Drawing.Size(383, 22)
        Me.smiSYM36.Text = "SYM36 - Shipping Forwarder Maintenance"
        '
        'smiSHM07
        '
        Me.smiSHM07.Name = "smiSHM07"
        Me.smiSHM07.Size = New System.Drawing.Size(383, 22)
        Me.smiSHM07.Text = "SHM07 - Shipping Charges Maintenance"
        '
        'ToolStripSeparator68
        '
        Me.ToolStripSeparator68.Name = "ToolStripSeparator68"
        Me.ToolStripSeparator68.Size = New System.Drawing.Size(380, 6)
        '
        'smiINR01
        '
        Me.smiINR01.Name = "smiINR01"
        Me.smiINR01.Size = New System.Drawing.Size(383, 22)
        Me.smiINR01.Text = "INR01 - Print Invoice"
        '
        'smiPKR01
        '
        Me.smiPKR01.Name = "smiPKR01"
        Me.smiPKR01.Size = New System.Drawing.Size(383, 22)
        Me.smiPKR01.Text = "PKR01 - Print Packing List"
        '
        'smiSHR10
        '
        Me.smiSHR10.Name = "smiSHR10"
        Me.smiSHR10.Size = New System.Drawing.Size(383, 22)
        Me.smiSHR10.Text = "SHR10 - Print Shipping Charges Report"
        '
        'ToolStripSeparator69
        '
        Me.ToolStripSeparator69.Name = "ToolStripSeparator69"
        Me.ToolStripSeparator69.Size = New System.Drawing.Size(380, 6)
        '
        'smiMSR09
        '
        Me.smiMSR09.Name = "smiMSR09"
        Me.smiMSR09.Size = New System.Drawing.Size(383, 22)
        Me.smiMSR09.Text = "MSR09 - Print Invoice Summary Report"
        '
        'smiMSR27
        '
        Me.smiMSR27.Name = "smiMSR27"
        Me.smiMSR27.Size = New System.Drawing.Size(383, 22)
        Me.smiMSR27.Text = "MSR27 - Print Container Search Report"
        '
        'smiMSR36
        '
        Me.smiMSR36.Name = "smiMSR36"
        Me.smiMSR36.Size = New System.Drawing.Size(383, 22)
        Me.smiMSR36.Text = "MSR36 - Print Container Summery Report By Customer"
        '
        'smiPGM
        '
        Me.smiPGM.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiSYM31, Me.ToolStripSeparator70, Me.smiPGM01, Me.ToolStripSeparator71, Me.smiPGM02, Me.smiPGM03, Me.smiPGX01, Me.smiPGR01, Me.ToolStripSeparator72, Me.smiPGM05, Me.smiPGM04, Me.smiPGM08, Me.ToolStripSeparator73, Me.smiPGM09, Me.ToolStripSeparator74, Me.msiPGM06, Me.smiPGM11, Me.smiPGM12, Me.smiPGM13, Me.ToolStripSeparator75, Me.msiPGM07})
        Me.smiPGM.Name = "smiPGM"
        Me.smiPGM.Size = New System.Drawing.Size(78, 19)
        Me.smiPGM.Text = "Packaging"
        '
        'smiSYM31
        '
        Me.smiSYM31.Name = "smiSYM31"
        Me.smiSYM31.Size = New System.Drawing.Size(394, 22)
        Me.smiSYM31.Text = "SYM31 - Packaging Component Maintenance"
        '
        'ToolStripSeparator70
        '
        Me.ToolStripSeparator70.Name = "ToolStripSeparator70"
        Me.ToolStripSeparator70.Size = New System.Drawing.Size(391, 6)
        '
        'smiPGM01
        '
        Me.smiPGM01.Name = "smiPGM01"
        Me.smiPGM01.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM01.Text = "PGM01 - Packaging Item Master Maintenance"
        '
        'ToolStripSeparator71
        '
        Me.ToolStripSeparator71.Name = "ToolStripSeparator71"
        Me.ToolStripSeparator71.Size = New System.Drawing.Size(391, 6)
        '
        'smiPGM02
        '
        Me.smiPGM02.Name = "smiPGM02"
        Me.smiPGM02.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM02.Text = "PGM02 - Packaging Request Maintenance"
        '
        'smiPGM03
        '
        Me.smiPGM03.Name = "smiPGM03"
        Me.smiPGM03.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM03.Text = "PGM03 - Release/Unrelease Packaging Request"
        '
        'smiPGX01
        '
        Me.smiPGX01.Name = "smiPGX01"
        Me.smiPGX01.Size = New System.Drawing.Size(394, 22)
        Me.smiPGX01.Text = "PGX01 - Excel Upload for Packaging Request Generation"
        '
        'smiPGR01
        '
        Me.smiPGR01.Name = "smiPGR01"
        Me.smiPGR01.Size = New System.Drawing.Size(394, 22)
        Me.smiPGR01.Text = "PGR01 - Packaging Request Information Export"
        '
        'ToolStripSeparator72
        '
        Me.ToolStripSeparator72.Name = "ToolStripSeparator72"
        Me.ToolStripSeparator72.Size = New System.Drawing.Size(391, 6)
        '
        'smiPGM05
        '
        Me.smiPGM05.Name = "smiPGM05"
        Me.smiPGM05.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM05.Text = "PGM05 - Packaging Order Generation and Update"
        '
        'smiPGM04
        '
        Me.smiPGM04.Name = "smiPGM04"
        Me.smiPGM04.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM04.Text = "PGM04 - Packaging Order Maintenance"
        '
        'smiPGM08
        '
        Me.smiPGM08.Name = "smiPGM08"
        Me.smiPGM08.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM08.Text = "PGM08 - Release/Unrelease Packaging Order"
        '
        'ToolStripSeparator73
        '
        Me.ToolStripSeparator73.Name = "ToolStripSeparator73"
        Me.ToolStripSeparator73.Size = New System.Drawing.Size(391, 6)
        '
        'smiPGM09
        '
        Me.smiPGM09.Name = "smiPGM09"
        Me.smiPGM09.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM09.Text = "PGM09 - Packaging Order Creation (Label/Hangtag)"
        '
        'ToolStripSeparator74
        '
        Me.ToolStripSeparator74.Name = "ToolStripSeparator74"
        Me.ToolStripSeparator74.Size = New System.Drawing.Size(391, 6)
        '
        'msiPGM06
        '
        Me.msiPGM06.Name = "msiPGM06"
        Me.msiPGM06.Size = New System.Drawing.Size(394, 22)
        Me.msiPGM06.Text = "PGM06 - Packaging Order Approval"
        '
        'smiPGM11
        '
        Me.smiPGM11.Name = "smiPGM11"
        Me.smiPGM11.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM11.Text = "PGM11 - Packaging Order Approval (Read Only)"
        '
        'smiPGM12
        '
        Me.smiPGM12.Name = "smiPGM12"
        Me.smiPGM12.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM12.Text = "PGM12 - Packaging Analysis Report"
        '
        'smiPGM13
        '
        Me.smiPGM13.Name = "smiPGM13"
        Me.smiPGM13.Size = New System.Drawing.Size(394, 22)
        Me.smiPGM13.Text = "PGM13 - Packaging Order Cost Comparsion Report"
        '
        'ToolStripSeparator75
        '
        Me.ToolStripSeparator75.Name = "ToolStripSeparator75"
        Me.ToolStripSeparator75.Size = New System.Drawing.Size(391, 6)
        '
        'msiPGM07
        '
        Me.msiPGM07.Name = "msiPGM07"
        Me.msiPGM07.Size = New System.Drawing.Size(394, 22)
        Me.msiPGM07.Text = "PGM07 - Print Packaging Order"
        '
        'ToolStripMenuItem421
        '
        Me.ToolStripMenuItem421.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiSYM37, Me.smiSYM38, Me.ToolStripSeparator76, Me.smiCLM01, Me.ToolStripSeparator77, Me.smiCLR04, Me.smiCLR05, Me.ToolStripSeparator78, Me.smiCLR01})
        Me.ToolStripMenuItem421.Name = "ToolStripMenuItem421"
        Me.ToolStripMenuItem421.Size = New System.Drawing.Size(56, 19)
        Me.ToolStripMenuItem421.Text = "Claims"
        '
        'smiSYM37
        '
        Me.smiSYM37.Name = "smiSYM37"
        Me.smiSYM37.Size = New System.Drawing.Size(375, 22)
        Me.smiSYM37.Text = "SYM37 - Claims Category Maintenance"
        '
        'smiSYM38
        '
        Me.smiSYM38.Name = "smiSYM38"
        Me.smiSYM38.Size = New System.Drawing.Size(375, 22)
        Me.smiSYM38.Text = "SYM38 - Claims Currency Maintenance"
        '
        'ToolStripSeparator76
        '
        Me.ToolStripSeparator76.Name = "ToolStripSeparator76"
        Me.ToolStripSeparator76.Size = New System.Drawing.Size(372, 6)
        '
        'smiCLM01
        '
        Me.smiCLM01.Name = "smiCLM01"
        Me.smiCLM01.Size = New System.Drawing.Size(375, 22)
        Me.smiCLM01.Text = "CLM01 - Claims Transaction Maintenance"
        '
        'ToolStripSeparator77
        '
        Me.ToolStripSeparator77.Name = "ToolStripSeparator77"
        Me.ToolStripSeparator77.Size = New System.Drawing.Size(372, 6)
        '
        'smiCLR04
        '
        Me.smiCLR04.Name = "smiCLR04"
        Me.smiCLR04.Size = New System.Drawing.Size(375, 22)
        Me.smiCLR04.Text = "CLR04 - Claims Analysis Report (Account Format)"
        '
        'smiCLR05
        '
        Me.smiCLR05.Name = "smiCLR05"
        Me.smiCLR05.Size = New System.Drawing.Size(375, 22)
        Me.smiCLR05.Text = "CLR05 - Claims Analysis Report (Summary List Format)"
        '
        'ToolStripSeparator78
        '
        Me.ToolStripSeparator78.Name = "ToolStripSeparator78"
        Me.ToolStripSeparator78.Size = New System.Drawing.Size(372, 6)
        '
        'smiCLR01
        '
        Me.smiCLR01.Name = "smiCLR01"
        Me.smiCLR01.Size = New System.Drawing.Size(375, 22)
        Me.smiCLR01.Text = "CLR01 - Print Claims Report"
        '
        'smiACR
        '
        Me.smiACR.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msiPCM01, Me.msiSYM32, Me.ToolStripSeparator79, Me.smiACR01, Me.ToolStripSeparator80, Me.smiSMR01, Me.smiSMR02})
        Me.smiACR.Name = "smiACR"
        Me.smiACR.Size = New System.Drawing.Size(65, 19)
        Me.smiACR.Text = "Account"
        '
        'msiPCM01
        '
        Me.msiPCM01.Name = "msiPCM01"
        Me.msiPCM01.Size = New System.Drawing.Size(343, 22)
        Me.msiPCM01.Text = "PCM01 - Account Setup Master"
        '
        'msiSYM32
        '
        Me.msiSYM32.Name = "msiSYM32"
        Me.msiSYM32.Size = New System.Drawing.Size(343, 22)
        Me.msiSYM32.Text = "SYM32 - Currency Maintenance (Account)"
        '
        'ToolStripSeparator79
        '
        Me.ToolStripSeparator79.Name = "ToolStripSeparator79"
        Me.ToolStripSeparator79.Size = New System.Drawing.Size(340, 6)
        '
        'smiACR01
        '
        Me.smiACR01.Name = "smiACR01"
        Me.smiACR01.Size = New System.Drawing.Size(343, 22)
        Me.smiACR01.Text = "ACR01 - LAI FEI Analysis Report"
        '
        'ToolStripSeparator80
        '
        Me.ToolStripSeparator80.Name = "ToolStripSeparator80"
        Me.ToolStripSeparator80.Size = New System.Drawing.Size(340, 6)
        '
        'smiSMR01
        '
        Me.smiSMR01.Name = "smiSMR01"
        Me.smiSMR01.Size = New System.Drawing.Size(343, 22)
        Me.smiSMR01.Text = "SMR01 - Shipment Matching Report"
        '
        'smiSMR02
        '
        Me.smiSMR02.Name = "smiSMR02"
        Me.smiSMR02.Size = New System.Drawing.Size(343, 22)
        Me.smiSMR02.Text = "SMR02 - Shipment Matching Report (Summary)"
        '
        'smiBFR01
        '
        Me.smiBFR01.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msiBJR01, Me.msiFTY01, Me.smiFTY04})
        Me.smiBFR01.Name = "smiBFR01"
        Me.smiBFR01.Size = New System.Drawing.Size(45, 19)
        Me.smiBFR01.Text = "PDO"
        '
        'msiBJR01
        '
        Me.msiBJR01.Name = "msiBJR01"
        Me.msiBJR01.Size = New System.Drawing.Size(249, 22)
        Me.msiBJR01.Text = "BJR01 - Batch Job Generation"
        '
        'msiFTY01
        '
        Me.msiFTY01.Name = "msiFTY01"
        Me.msiFTY01.Size = New System.Drawing.Size(249, 22)
        Me.msiFTY01.Text = "FTY01 - PDO System"
        '
        'smiFTY04
        '
        Me.smiFTY04.Name = "smiFTY04"
        Me.smiFTY04.Size = New System.Drawing.Size(249, 22)
        Me.smiFTY04.Text = "FTY04 - PDO Document History"
        '
        'ToolStripMenuItem438
        '
        Me.ToolStripMenuItem438.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiMPM01, Me.smiMPM02, Me.smiMPM03, Me.ToolStripSeparator81, Me.smiMPO01, Me.smiMPO02, Me.smiMPO03, Me.ToolStripSeparator82, Me.smiMPR01, Me.smiMPR02, Me.smiMPR03, Me.smiMPR04, Me.smiMPR05, Me.smiMPR06, Me.ToolStripSeparator83, Me.smiMIM01, Me.smiMIM02, Me.smiSYM20})
        Me.ToolStripMenuItem438.Name = "ToolStripMenuItem438"
        Me.ToolStripMenuItem438.Size = New System.Drawing.Size(48, 19)
        Me.ToolStripMenuItem438.Text = "MPO"
        '
        'smiMPM01
        '
        Me.smiMPM01.Name = "smiMPM01"
        Me.smiMPM01.Size = New System.Drawing.Size(443, 22)
        Me.smiMPM01.Text = "MPM01 - Manufacturing Purchase Order Maintenance"
        '
        'smiMPM02
        '
        Me.smiMPM02.Name = "smiMPM02"
        Me.smiMPM02.Size = New System.Drawing.Size(443, 22)
        Me.smiMPM02.Text = "MPM02 - GRN Transfer Maintenance"
        '
        'smiMPM03
        '
        Me.smiMPM03.Name = "smiMPM03"
        Me.smiMPM03.Size = New System.Drawing.Size(443, 22)
        Me.smiMPM03.Text = "MPM03 - Supplier Delivery Maintenance"
        '
        'ToolStripSeparator81
        '
        Me.ToolStripSeparator81.Name = "ToolStripSeparator81"
        Me.ToolStripSeparator81.Size = New System.Drawing.Size(440, 6)
        '
        'smiMPO01
        '
        Me.smiMPO01.Name = "smiMPO01"
        Me.smiMPO01.Size = New System.Drawing.Size(443, 22)
        Me.smiMPO01.Text = "MPO01 - (WT) Manufacturing Purchase Order Search"
        '
        'smiMPO02
        '
        Me.smiMPO02.Name = "smiMPO02"
        Me.smiMPO02.Size = New System.Drawing.Size(443, 22)
        Me.smiMPO02.Text = "MPO02 - (WT) Manufacturing Purchase Order Generation"
        '
        'smiMPO03
        '
        Me.smiMPO03.Name = "smiMPO03"
        Me.smiMPO03.Size = New System.Drawing.Size(443, 22)
        Me.smiMPO03.Text = "MPO03 - (WT) Manufacturing Purchase Order Approval/Rejection"
        '
        'ToolStripSeparator82
        '
        Me.ToolStripSeparator82.Name = "ToolStripSeparator82"
        Me.ToolStripSeparator82.Size = New System.Drawing.Size(440, 6)
        '
        'smiMPR01
        '
        Me.smiMPR01.Name = "smiMPR01"
        Me.smiMPR01.Size = New System.Drawing.Size(443, 22)
        Me.smiMPR01.Text = "MPR01 - (WT) Manufacturing Purchase Order Exception Report"
        '
        'smiMPR02
        '
        Me.smiMPR02.Name = "smiMPR02"
        Me.smiMPR02.Size = New System.Drawing.Size(443, 22)
        Me.smiMPR02.Text = "MPR02 - Print Manufacturing Purchase Order"
        '
        'smiMPR03
        '
        Me.smiMPR03.Name = "smiMPR03"
        Me.smiMPR03.Size = New System.Drawing.Size(443, 22)
        Me.smiMPR03.Text = "MPR03 - GRN Transfer Reports"
        '
        'smiMPR04
        '
        Me.smiMPR04.Name = "smiMPR04"
        Me.smiMPR04.Size = New System.Drawing.Size(443, 22)
        Me.smiMPR04.Text = "MPR04 - MPO Item Master Listing"
        '
        'smiMPR05
        '
        Me.smiMPR05.Name = "smiMPR05"
        Me.smiMPR05.Size = New System.Drawing.Size(443, 22)
        Me.smiMPR05.Text = "MPR05 - GRN Transaction List (Adhoc Misc Type Only)"
        '
        'smiMPR06
        '
        Me.smiMPR06.Name = "smiMPR06"
        Me.smiMPR06.Size = New System.Drawing.Size(443, 22)
        Me.smiMPR06.Text = "MPR06 - MPR Transaction Statistics Report"
        '
        'ToolStripSeparator83
        '
        Me.ToolStripSeparator83.Name = "ToolStripSeparator83"
        Me.ToolStripSeparator83.Size = New System.Drawing.Size(440, 6)
        '
        'smiMIM01
        '
        Me.smiMIM01.Name = "smiMIM01"
        Me.smiMIM01.Size = New System.Drawing.Size(443, 22)
        Me.smiMIM01.Text = "MIM01 - WT Factory Item Master"
        '
        'smiMIM02
        '
        Me.smiMIM02.Name = "smiMIM02"
        Me.smiMIM02.Size = New System.Drawing.Size(443, 22)
        Me.smiMIM02.Text = "MIM02 - Item Master Approval Rejection (WT)"
        '
        'smiSYM20
        '
        Me.smiSYM20.Name = "smiSYM20"
        Me.smiSYM20.Size = New System.Drawing.Size(443, 22)
        Me.smiSYM20.Text = "SYM20 - PRC Item Category Maintenance"
        '
        'msiQC
        '
        Me.msiQC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiSYM39, Me.smiSYM40, Me.ToolStripSeparator84, Me.smiQCM01, Me.smiQCM02, Me.smiQCM03, Me.ToolStripSeparator85, Me.smiQCM04, Me.smiQCM09, Me.ToolStripSeparator86, Me.smiQCM05, Me.smiQCM06, Me.ToolStripSeparator87, Me.smiQCM07})
        Me.msiQC.Name = "msiQC"
        Me.msiQC.Size = New System.Drawing.Size(37, 19)
        Me.msiQC.Text = "QC"
        '
        'smiSYM39
        '
        Me.smiSYM39.Name = "smiSYM39"
        Me.smiSYM39.Size = New System.Drawing.Size(371, 22)
        Me.smiSYM39.Text = "SYM39 - SZ Sales Team Maintenance"
        '
        'smiSYM40
        '
        Me.smiSYM40.Name = "smiSYM40"
        Me.smiSYM40.Size = New System.Drawing.Size(371, 22)
        Me.smiSYM40.Text = "SYM40 - AQL Maintenance"
        '
        'ToolStripSeparator84
        '
        Me.ToolStripSeparator84.Name = "ToolStripSeparator84"
        Me.ToolStripSeparator84.Size = New System.Drawing.Size(368, 6)
        '
        'smiQCM01
        '
        Me.smiQCM01.Name = "smiQCM01"
        Me.smiQCM01.Size = New System.Drawing.Size(371, 22)
        Me.smiQCM01.Text = "QCM01 - QC Inspection Request Generation"
        '
        'smiQCM02
        '
        Me.smiQCM02.Name = "smiQCM02"
        Me.smiQCM02.Size = New System.Drawing.Size(371, 22)
        Me.smiQCM02.Text = "QCM02 - QC Inspection Request Maintenance"
        '
        'smiQCM03
        '
        Me.smiQCM03.Name = "smiQCM03"
        Me.smiQCM03.Size = New System.Drawing.Size(371, 22)
        Me.smiQCM03.Text = "QCM03 - Release / Unrelease QC Inspection Request"
        '
        'ToolStripSeparator85
        '
        Me.ToolStripSeparator85.Name = "ToolStripSeparator85"
        Me.ToolStripSeparator85.Size = New System.Drawing.Size(368, 6)
        '
        'smiQCM04
        '
        Me.smiQCM04.Name = "smiQCM04"
        Me.smiQCM04.Size = New System.Drawing.Size(371, 22)
        Me.smiQCM04.Text = "QCM04 - QC Inspection Request Summary"
        '
        'smiQCM09
        '
        Me.smiQCM09.Name = "smiQCM09"
        Me.smiQCM09.Size = New System.Drawing.Size(371, 22)
        Me.smiQCM09.Text = "QCM09 - QC Attachment Maintenance"
        '
        'ToolStripSeparator86
        '
        Me.ToolStripSeparator86.Name = "ToolStripSeparator86"
        Me.ToolStripSeparator86.Size = New System.Drawing.Size(368, 6)
        '
        'smiQCM05
        '
        Me.smiQCM05.Name = "smiQCM05"
        Me.smiQCM05.Size = New System.Drawing.Size(371, 22)
        Me.smiQCM05.Text = "QCM05 - QC Inspection Request List (Summary)"
        '
        'smiQCM06
        '
        Me.smiQCM06.Name = "smiQCM06"
        Me.smiQCM06.Size = New System.Drawing.Size(371, 22)
        Me.smiQCM06.Text = "QCM06 - QC Inspection Request Check List"
        '
        'ToolStripSeparator87
        '
        Me.ToolStripSeparator87.Name = "ToolStripSeparator87"
        Me.ToolStripSeparator87.Size = New System.Drawing.Size(368, 6)
        '
        'smiQCM07
        '
        Me.smiQCM07.Name = "smiQCM07"
        Me.smiQCM07.Size = New System.Drawing.Size(371, 22)
        Me.smiQCM07.Text = "QCM07 - QC Report History Summary"
        '
        'ToolStripMenuItem465
        '
        Me.ToolStripMenuItem465.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem466, Me.ToolStripMenuItem476, Me.ToolStripSeparator4, Me.ToolStripMenuItem483, Me.ToolStripMenuItem489, Me.ToolStripMenuItem495, Me.smiINR132, Me.ToolStripMenuItem501, Me.ToolStripSeparator5, Me.ToolStripMenuItem503, Me.ToolStripSeparator88, Me.smiCOR01})
        Me.ToolStripMenuItem465.Name = "ToolStripMenuItem465"
        Me.ToolStripMenuItem465.Size = New System.Drawing.Size(58, 19)
        Me.ToolStripMenuItem465.Text = "Report"
        '
        'ToolStripMenuItem466
        '
        Me.ToolStripMenuItem466.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiIAR01, Me.smiIMR17, Me.smiMSR32, Me.smiIMR13, Me.smiIMR23, Me.smiIMR27, Me.smiIMR21, Me.smiIMR22, Me.ToolStripSeparator3, Me.smiINR14})
        Me.ToolStripMenuItem466.Name = "ToolStripMenuItem466"
        Me.ToolStripMenuItem466.Size = New System.Drawing.Size(296, 22)
        Me.ToolStripMenuItem466.Text = "Item Information Report"
        '
        'smiIAR01
        '
        Me.smiIAR01.Name = "smiIAR01"
        Me.smiIAR01.Size = New System.Drawing.Size(357, 22)
        Me.smiIAR01.Text = "IAR01 - Impact Analysis Report"
        '
        'smiIMR17
        '
        Me.smiIMR17.Name = "smiIMR17"
        Me.smiIMR17.Size = New System.Drawing.Size(357, 22)
        Me.smiIMR17.Text = "IMR17 - Item Pricing Report (Export to Excel)"
        '
        'smiMSR32
        '
        Me.smiMSR32.Name = "smiMSR32"
        Me.smiMSR32.Size = New System.Drawing.Size(357, 22)
        Me.smiMSR32.Text = "MSR32 - Document List by Item"
        '
        'smiIMR13
        '
        Me.smiIMR13.Name = "smiIMR13"
        Me.smiIMR13.Size = New System.Drawing.Size(357, 22)
        Me.smiIMR13.Text = "IMR13 - Item Image Analyst Report"
        '
        'smiIMR23
        '
        Me.smiIMR23.Name = "smiIMR23"
        Me.smiIMR23.Size = New System.Drawing.Size(357, 22)
        Me.smiIMR23.Text = "IMR23 - Export Item Image to Excel"
        '
        'smiIMR27
        '
        Me.smiIMR27.Name = "smiIMR27"
        Me.smiIMR27.Size = New System.Drawing.Size(357, 22)
        Me.smiIMR27.Text = "IMR27 - Export Item Image to Excel (with Barcode)"
        '
        'smiIMR21
        '
        Me.smiIMR21.Name = "smiIMR21"
        Me.smiIMR21.Size = New System.Drawing.Size(357, 22)
        Me.smiIMR21.Text = "IMR21 - Assorted Item List"
        '
        'smiIMR22
        '
        Me.smiIMR22.Name = "smiIMR22"
        Me.smiIMR22.Size = New System.Drawing.Size(357, 22)
        Me.smiIMR22.Text = "IMR22 - Customer Alias Item List"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(354, 6)
        '
        'smiINR14
        '
        Me.smiINR14.Name = "smiINR14"
        Me.smiINR14.Size = New System.Drawing.Size(357, 22)
        Me.smiINR14.Text = "INR14 - CBM Report"
        '
        'ToolStripMenuItem476
        '
        Me.ToolStripMenuItem476.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiMSR02, Me.smiMSR19, Me.smiMSR20, Me.smiMSR22, Me.smiMSR31, Me.smiMSR33})
        Me.ToolStripMenuItem476.Name = "ToolStripMenuItem476"
        Me.ToolStripMenuItem476.Size = New System.Drawing.Size(296, 22)
        Me.ToolStripMenuItem476.Text = "Document Index / Record Listing"
        '
        'smiMSR02
        '
        Me.smiMSR02.Name = "smiMSR02"
        Me.smiMSR02.Size = New System.Drawing.Size(266, 22)
        Me.smiMSR02.Text = "MSR02 - Quotation Index"
        '
        'smiMSR19
        '
        Me.smiMSR19.Name = "smiMSR19"
        Me.smiMSR19.Size = New System.Drawing.Size(266, 22)
        Me.smiMSR19.Text = "MSR19 - Sales Confirmation Index"
        '
        'smiMSR20
        '
        Me.smiMSR20.Name = "smiMSR20"
        Me.smiMSR20.Size = New System.Drawing.Size(266, 22)
        Me.smiMSR20.Text = "MSR20 - Purchase Order Index"
        '
        'smiMSR22
        '
        Me.smiMSR22.Name = "smiMSR22"
        Me.smiMSR22.Size = New System.Drawing.Size(266, 22)
        Me.smiMSR22.Text = "MSR22 - BOM PO Index"
        '
        'smiMSR31
        '
        Me.smiMSR31.Name = "smiMSR31"
        Me.smiMSR31.Size = New System.Drawing.Size(266, 22)
        Me.smiMSR31.Text = "MSR31 - Invoice Index"
        '
        'smiMSR33
        '
        Me.smiMSR33.Name = "smiMSR33"
        Me.smiMSR33.Size = New System.Drawing.Size(266, 22)
        Me.smiMSR33.Text = "MSR33 - Sample Invoice Index"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(293, 6)
        '
        'ToolStripMenuItem483
        '
        Me.ToolStripMenuItem483.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msiMSR01, Me.msiMSR04, Me.msiMSR12, Me.msiMSR05, Me.msiMSR35})
        Me.ToolStripMenuItem483.Name = "ToolStripMenuItem483"
        Me.ToolStripMenuItem483.Size = New System.Drawing.Size(296, 22)
        Me.ToolStripMenuItem483.Text = "Outstanding Reports"
        '
        'msiMSR01
        '
        Me.msiMSR01.Name = "msiMSR01"
        Me.msiMSR01.Size = New System.Drawing.Size(363, 22)
        Me.msiMSR01.Text = "MSR01 - Outstanding Report By Sales Confirmation"
        '
        'msiMSR04
        '
        Me.msiMSR04.Name = "msiMSR04"
        Me.msiMSR04.Size = New System.Drawing.Size(363, 22)
        Me.msiMSR04.Text = "MSR04 - Outstanding Report By Vendor"
        '
        'msiMSR12
        '
        Me.msiMSR12.Name = "msiMSR12"
        Me.msiMSR12.Size = New System.Drawing.Size(363, 22)
        Me.msiMSR12.Text = "MSR12 - Outstanding Report By Customer"
        '
        'msiMSR05
        '
        Me.msiMSR05.Name = "msiMSR05"
        Me.msiMSR05.Size = New System.Drawing.Size(363, 22)
        Me.msiMSR05.Text = "MSR05 - Outstanding Report By Purchase Order"
        '
        'msiMSR35
        '
        Me.msiMSR35.Name = "msiMSR35"
        Me.msiMSR35.Size = New System.Drawing.Size(363, 22)
        Me.msiMSR35.Text = "MSR35 - Outstanding Report (Shipping)"
        '
        'ToolStripMenuItem489
        '
        Me.ToolStripMenuItem489.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msiIMR19, Me.smiINR11, Me.smiSCR02, Me.smiMSR07, Me.smiBSP04})
        Me.ToolStripMenuItem489.Name = "ToolStripMenuItem489"
        Me.ToolStripMenuItem489.Size = New System.Drawing.Size(296, 22)
        Me.ToolStripMenuItem489.Text = "Sales Analysis Reports"
        '
        'msiIMR19
        '
        Me.msiIMR19.Name = "msiIMR19"
        Me.msiIMR19.Size = New System.Drawing.Size(350, 22)
        Me.msiIMR19.Text = "IMR19 - External Item Image List (Export to Excel)"
        '
        'smiINR11
        '
        Me.smiINR11.Name = "smiINR11"
        Me.smiINR11.Size = New System.Drawing.Size(350, 22)
        Me.smiINR11.Text = "INR11 - S/C Summary Report"
        '
        'smiSCR02
        '
        Me.smiSCR02.Name = "smiSCR02"
        Me.smiSCR02.Size = New System.Drawing.Size(350, 22)
        Me.smiSCR02.Text = "SCR02 - Sales Confirmation Analysis Report"
        '
        'smiMSR07
        '
        Me.smiMSR07.Name = "smiMSR07"
        Me.smiMSR07.Size = New System.Drawing.Size(350, 22)
        Me.smiMSR07.Text = "MSR07 - Customer Item History Report"
        '
        'smiBSP04
        '
        Me.smiBSP04.Name = "smiBSP04"
        Me.smiBSP04.Size = New System.Drawing.Size(350, 22)
        Me.smiBSP04.Text = "BSP04 - Sales Analysis By Designer"
        '
        'ToolStripMenuItem495
        '
        Me.ToolStripMenuItem495.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiINR04, Me.smiINR10})
        Me.ToolStripMenuItem495.Name = "ToolStripMenuItem495"
        Me.ToolStripMenuItem495.Size = New System.Drawing.Size(296, 22)
        Me.ToolStripMenuItem495.Text = "Purchases / Production Analysis Reports"
        '
        'smiINR04
        '
        Me.smiINR04.Name = "smiINR04"
        Me.smiINR04.Size = New System.Drawing.Size(352, 22)
        Me.smiINR04.Text = "INR04 - Production Capacity in CBM Report"
        '
        'smiINR10
        '
        Me.smiINR10.Name = "smiINR10"
        Me.smiINR10.Size = New System.Drawing.Size(352, 22)
        Me.smiINR10.Text = "INR10 - CBM Ordered Report (Factory Ship-Date)"
        '
        'smiINR132
        '
        Me.smiINR132.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiINR13, Me.smiINR12})
        Me.smiINR132.Name = "smiINR132"
        Me.smiINR132.Size = New System.Drawing.Size(296, 22)
        Me.smiINR132.Text = "Shipping / Invoice Analysis Reports"
        '
        'smiINR13
        '
        Me.smiINR13.Name = "smiINR13"
        Me.smiINR13.Size = New System.Drawing.Size(269, 22)
        Me.smiINR13.Text = "INR13 - Shipping Summary Report"
        '
        'smiINR12
        '
        Me.smiINR12.Name = "smiINR12"
        Me.smiINR12.Size = New System.Drawing.Size(269, 22)
        Me.smiINR12.Text = "INR12 - Shipping Schedule Report"
        '
        'ToolStripMenuItem501
        '
        Me.ToolStripMenuItem501.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiMSR08})
        Me.ToolStripMenuItem501.Name = "ToolStripMenuItem501"
        Me.ToolStripMenuItem501.Size = New System.Drawing.Size(296, 22)
        Me.ToolStripMenuItem501.Text = "Sample Order Reports"
        '
        'smiMSR08
        '
        Me.smiMSR08.Name = "smiMSR08"
        Me.smiMSR08.Size = New System.Drawing.Size(348, 22)
        Me.smiMSR08.Text = "MSR08 - Monthly Statement for Sample Charges"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(293, 6)
        '
        'ToolStripMenuItem503
        '
        Me.ToolStripMenuItem503.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiDYR01, Me.smiDYR02, Me.smiDYR03, Me.smiDYR04, Me.smiDYR05, Me.smiDYR06, Me.smiDYR07, Me.smiDYR08, Me.smiDYR09, Me.smiDYR10})
        Me.ToolStripMenuItem503.Name = "ToolStripMenuItem503"
        Me.ToolStripMenuItem503.Size = New System.Drawing.Size(296, 22)
        Me.ToolStripMenuItem503.Text = "Data Extraction"
        '
        'smiDYR01
        '
        Me.smiDYR01.Name = "smiDYR01"
        Me.smiDYR01.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR01.Text = "DYR01 - vw_CIH_Repoort"
        '
        'smiDYR02
        '
        Me.smiDYR02.Name = "smiDYR02"
        Me.smiDYR02.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR02.Text = "DYR02 - vw_CusMaster_EC2"
        '
        'smiDYR03
        '
        Me.smiDYR03.Name = "smiDYR03"
        Me.smiDYR03.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR03.Text = "DYR03 - vw_ItemMaster"
        '
        'smiDYR04
        '
        Me.smiDYR04.Name = "smiDYR04"
        Me.smiDYR04.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR04.Text = "DYR04 - vw_ItemMaster_Hist"
        '
        'smiDYR05
        '
        Me.smiDYR05.Name = "smiDYR05"
        Me.smiDYR05.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR05.Text = "DYR05 - vw_SYSETINF"
        '
        'smiDYR06
        '
        Me.smiDYR06.Name = "smiDYR06"
        Me.smiDYR06.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR06.Text = "DYR06 - vw_Quotation"
        '
        'smiDYR07
        '
        Me.smiDYR07.Name = "smiDYR07"
        Me.smiDYR07.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR07.Text = "DYR07 - vw_SampleInvoice"
        '
        'smiDYR08
        '
        Me.smiDYR08.Name = "smiDYR08"
        Me.smiDYR08.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR08.Text = "DYR08 - vw_SampleRequest"
        '
        'smiDYR09
        '
        Me.smiDYR09.Name = "smiDYR09"
        Me.smiDYR09.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR09.Text = "DYR09 - vw_SalesConfirmation_EC"
        '
        'smiDYR10
        '
        Me.smiDYR10.Name = "smiDYR10"
        Me.smiDYR10.Size = New System.Drawing.Size(266, 22)
        Me.smiDYR10.Text = "DYR10 - vw_ShippingInfo"
        '
        'ToolStripSeparator88
        '
        Me.ToolStripSeparator88.Name = "ToolStripSeparator88"
        Me.ToolStripSeparator88.Size = New System.Drawing.Size(293, 6)
        '
        'smiCOR01
        '
        Me.smiCOR01.Name = "smiCOR01"
        Me.smiCOR01.Size = New System.Drawing.Size(296, 22)
        Me.smiCOR01.Text = "COR01 - Audit Trail Report"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(66, 19)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 42)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 681)
        Me.Splitter1.TabIndex = 16
        Me.Splitter1.TabStop = False
        Me.Splitter1.Visible = False
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter2.Location = New System.Drawing.Point(989, 42)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 681)
        Me.Splitter2.TabIndex = 18
        Me.Splitter2.TabStop = False
        Me.Splitter2.Visible = False
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuBarSetup, Me.ts0, Me.DocumentDiagramToolStripStatusLabel, Me.ts1, Me.LeftMenuToolStripStatusLabel, Me.ts2, Me.RightMenuToolStripStatusLabel, Me.t3})
        Me.StatusStrip.Location = New System.Drawing.Point(3, 701)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(986, 22)
        Me.StatusStrip.TabIndex = 24
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'MenuBarSetup
        '
        Me.MenuBarSetup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TopMenuBarMainOnToolStripMenuItem, Me.TopMenuBarERPOnToolStripMenuItem, Me.btnOldEnableStyle, Me.btnOldVisibleStyle, Me.btnNewMenuEnableStyle, Me.btnNewVisibleStyle})
        Me.MenuBarSetup.Image = CType(resources.GetObject("MenuBarSetup.Image"), System.Drawing.Image)
        Me.MenuBarSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuBarSetup.Name = "MenuBarSetup"
        Me.MenuBarSetup.Size = New System.Drawing.Size(126, 20)
        Me.MenuBarSetup.Text = "Menu Bar Setup"
        '
        'TopMenuBarMainOnToolStripMenuItem
        '
        Me.TopMenuBarMainOnToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TopMenuBarMainOnToolStripMenuItem.Name = "TopMenuBarMainOnToolStripMenuItem"
        Me.TopMenuBarMainOnToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.TopMenuBarMainOnToolStripMenuItem.Text = "Top Menu Bar (Main) - On"
        Me.TopMenuBarMainOnToolStripMenuItem.Visible = False
        '
        'TopMenuBarERPOnToolStripMenuItem
        '
        Me.TopMenuBarERPOnToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TopMenuBarERPOnToolStripMenuItem.Name = "TopMenuBarERPOnToolStripMenuItem"
        Me.TopMenuBarERPOnToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.TopMenuBarERPOnToolStripMenuItem.Text = "Top Menu Bar (ERP) - On"
        Me.TopMenuBarERPOnToolStripMenuItem.Visible = False
        '
        'btnOldEnableStyle
        '
        Me.btnOldEnableStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOldEnableStyle.Name = "btnOldEnableStyle"
        Me.btnOldEnableStyle.Size = New System.Drawing.Size(300, 22)
        Me.btnOldEnableStyle.Text = "1 - LongCode MenuBar (Enable version)"
        '
        'btnOldVisibleStyle
        '
        Me.btnOldVisibleStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOldVisibleStyle.Name = "btnOldVisibleStyle"
        Me.btnOldVisibleStyle.Size = New System.Drawing.Size(300, 22)
        Me.btnOldVisibleStyle.Text = "2 - LongCode MenuBar (Visible version)"
        '
        'btnNewMenuEnableStyle
        '
        Me.btnNewMenuEnableStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnNewMenuEnableStyle.Name = "btnNewMenuEnableStyle"
        Me.btnNewMenuEnableStyle.Size = New System.Drawing.Size(300, 22)
        Me.btnNewMenuEnableStyle.Text = "3 - ShortCode MenuBar (Enable version)"
        '
        'btnNewVisibleStyle
        '
        Me.btnNewVisibleStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnNewVisibleStyle.Name = "btnNewVisibleStyle"
        Me.btnNewVisibleStyle.Size = New System.Drawing.Size(300, 22)
        Me.btnNewVisibleStyle.Text = "4 - ShortCode MenuBar (Visible version)"
        '
        'ts0
        '
        Me.ts0.Name = "ts0"
        Me.ts0.Size = New System.Drawing.Size(10, 17)
        Me.ts0.Text = "|"
        Me.ts0.Visible = False
        '
        'DocumentDiagramToolStripStatusLabel
        '
        Me.DocumentDiagramToolStripStatusLabel.Name = "DocumentDiagramToolStripStatusLabel"
        Me.DocumentDiagramToolStripStatusLabel.Size = New System.Drawing.Size(146, 17)
        Me.DocumentDiagramToolStripStatusLabel.Text = "Document Diagram - On"
        Me.DocumentDiagramToolStripStatusLabel.Visible = False
        '
        'ts1
        '
        Me.ts1.Name = "ts1"
        Me.ts1.Size = New System.Drawing.Size(10, 17)
        Me.ts1.Text = "|"
        Me.ts1.Visible = False
        '
        'LeftMenuToolStripStatusLabel
        '
        Me.LeftMenuToolStripStatusLabel.Name = "LeftMenuToolStripStatusLabel"
        Me.LeftMenuToolStripStatusLabel.Size = New System.Drawing.Size(113, 17)
        Me.LeftMenuToolStripStatusLabel.Text = "Left Menu Bar - On"
        Me.LeftMenuToolStripStatusLabel.Visible = False
        '
        'ts2
        '
        Me.ts2.Name = "ts2"
        Me.ts2.Size = New System.Drawing.Size(10, 17)
        Me.ts2.Text = "|"
        Me.ts2.Visible = False
        '
        'RightMenuToolStripStatusLabel
        '
        Me.RightMenuToolStripStatusLabel.Name = "RightMenuToolStripStatusLabel"
        Me.RightMenuToolStripStatusLabel.Size = New System.Drawing.Size(122, 17)
        Me.RightMenuToolStripStatusLabel.Text = "Right Menu Bar - On"
        Me.RightMenuToolStripStatusLabel.Visible = False
        '
        't3
        '
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(10, 17)
        Me.t3.Text = "|"
        Me.t3.Visible = False
        '
        'lbmenu2
        '
        Me.lbmenu2.ItemHeight = 12
        Me.lbmenu2.Location = New System.Drawing.Point(43, 35)
        Me.lbmenu2.Name = "lbmenu2"
        Me.lbmenu2.Size = New System.Drawing.Size(96, 4)
        Me.lbmenu2.TabIndex = 26
        Me.lbmenu2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(240, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 10)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "reset"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(343, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 17)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "enable"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(405, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(56, 17)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "visible"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'btnToLong
        '
        Me.btnToLong.Location = New System.Drawing.Point(192, 29)
        Me.btnToLong.Name = "btnToLong"
        Me.btnToLong.Size = New System.Drawing.Size(79, 10)
        Me.btnToLong.TabIndex = 31
        Me.btnToLong.Text = "long name"
        Me.btnToLong.UseVisualStyleBackColor = True
        Me.btnToLong.Visible = False
        '
        'btnToShort
        '
        Me.btnToShort.Location = New System.Drawing.Point(405, 7)
        Me.btnToShort.Name = "btnToShort"
        Me.btnToShort.Size = New System.Drawing.Size(79, 10)
        Me.btnToShort.TabIndex = 32
        Me.btnToShort.Text = "Short name"
        Me.btnToShort.UseVisualStyleBackColor = True
        Me.btnToShort.Visible = False
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.AutoSize = False
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(100, 19)
        '
        'ERP00000new
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(992, 723)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.msMenuERP)
        Me.Controls.Add(Me.lbmenu2)
        Me.Controls.Add(Me.btnToShort)
        Me.Controls.Add(Me.btnToLong)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbMenu)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "ERP00000new"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "s"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.msMenuERP.ResumeLayout(False)
        Me.msMenuERP.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim timeout As Timer
    Const timeout_tick As Integer = 1000
    Const timeout_max As Integer = 3600000
    Dim menuMode As String
    Dim curFormNameMode As String
    Dim displayMode As String
    Private Sub miExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ERP00000_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbMenu.Visible = False

        'SkipExitMsg = False

        '1. Menu Rights Check
        Dim i, j, k As Integer
        'Dim rs_SYUSRGRP As New DataSet
        Dim ms1 As ToolStripMenuItem
        Dim ms2 As ToolStripMenuItem
        Dim ms3 As ToolStripMenuItem
        Dim m1 As New MenuItem
        Dim m2 As New MenuItem
        Dim m3 As New MenuItem

        Dim s1, s2, s3 As String

        gspStr = "sp_select_SYUSRGRP_1 '', 'UCG','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRGRP_right, rtnStr)

        If rtnLong = RC_SUCCESS Then

            For i = 0 To rs_SYUSRGRP_right.Tables("RESULT").Rows.Count() - 1
                lbmenu2.Items.Add(rs_SYUSRGRP_right.Tables("RESULT").Rows(i).Item("yug_usrfun2"))
            Next
            curFormNameMode = "SHORT"

            displayMode = "INIT"
            SetMuneMode(gsUsrID)

            timeout = New Timer()
            timeout.Interval = timeout_tick
            timeout.Interval = timeout_max
            timeout.Enabled = True
            AddHandler timeout.Tick, AddressOf timeout_Trigger
        End If
        setDropdownAutofit(Me.msMenuERP)


        MenuBarSetup.Visible = True

    End Sub
    Private Sub setDropdownAutofit(ByRef menustrip As MenuStrip)

        Dim i, j, k As Integer
        Dim ms1 As ToolStripMenuItem
        Dim ms2 As ToolStripMenuItem
        Dim ms3 As ToolStripMenuItem
        Dim m1 As ToolStripMenuItem
        Dim m2 As ToolStripMenuItem
        Dim m3 As ToolStripMenuItem


        Dim s1, s2, s3 As String
        For i = 1 To menustrip.Items.Count - 1
            If TypeOf menustrip.Items(i) Is ToolStripTextBox Then
                Continue For

            End If
            If TypeOf menustrip.Items(i) Is ToolStripSeparator Then
                Continue For

            End If
            m1 = menustrip.Items(i)
            '

            Dim AutoFitLy1 As Boolean = True
            For j = 0 To m1.DropDownItems.Count - 1

                If TypeOf m1.DropDownItems(j) Is ToolStripSeparator Then
                    Continue For

                End If
                m2 = m1.DropDownItems(j)
                Dim AutoFitLy2 As Boolean = True
                For k = 0 To m2.DropDownItems.Count - 1

                    If TypeOf m2.DropDownItems(k) Is ToolStripSeparator Then
                        Continue For

                    End If
                    m3 = m2.DropDownItems(k)

                    If m3.DropDownItems.Count > 0 Then
                        AutoFitLy1 = False
                        AutoFitLy2 = False
                    End If
                Next
                If m2.DropDownItems.Count > 0 And AutoFitLy2 Then
                    AutoFitLy1 = False
                    AddHandler m2.DropDownOpening, AddressOf autosetMenuWidth
                    AddHandler m2.DropDownOpened, AddressOf autosetMenuHeight
                End If
            Next
            If m1.DropDownItems.Count > 0 And AutoFitLy1 Then
                AddHandler m1.DropDownOpening, AddressOf autosetMenuWidth
                AddHandler m1.DropDownOpened, AddressOf autosetMenuHeight
            End If
        Next
    End Sub
    Private Sub setAllMenuItem(ByRef menustrip As MenuStrip)
        resetAllMenuItem(menustrip)
        If curFormNameMode = "SHORT" Then
            'setshortname
            setShortName(menustrip)
            ToolStripTextBox2.Visible = True
        Else ''INIT' or "LONG"
            'setlongname
            setLongName(menustrip)
        End If

        If displayMode = "VISIBLE" Then
            'setVISIBLE
            setVisible(menustrip)
        Else 'INIT' or "ENABLE"
            'setEnable
            setEnabled(menustrip)
        End If

    End Sub
    Private Sub resetAllMenuItem(ByRef menustrip As MenuStrip)

        Dim i, j, k As Integer
        Dim ms1 As ToolStripMenuItem
        Dim ms2 As ToolStripMenuItem
        Dim ms3 As ToolStripMenuItem
        Dim m1 As ToolStripMenuItem
        Dim m2 As ToolStripMenuItem
        Dim m3 As ToolStripMenuItem

        Dim s1, s2, s3 As String
        For i = 1 To menustrip.Items.Count - 1
            If TypeOf menustrip.Items(i) Is ToolStripTextBox Then
                menustrip.Items(i).Visible = True
                Continue For

            End If
            If TypeOf menustrip.Items(i) Is ToolStripSeparator Then
                menustrip.Items(i).Visible = True
                Continue For

            End If
            m1 = menustrip.Items(i)

            m1.Enabled = True
            m1.Visible = True

            For j = 0 To m1.DropDownItems.Count - 1

                If TypeOf m1.DropDownItems(j) Is ToolStripSeparator Then
                    m1.DropDownItems(j).Visible = True
                    Continue For

                End If
                m2 = m1.DropDownItems(j)
                m2.Enabled = True
                m2.Visible = True
                For k = 0 To m2.DropDownItems.Count - 1

                    If TypeOf m2.DropDownItems(k) Is ToolStripSeparator Then
                        m2.DropDownItems(k).Visible = True
                        Continue For

                    End If
                    m3 = m2.DropDownItems(k)
                    m3.Enabled = True
                    m3.Visible = True
                Next
            Next
        Next
    End Sub
    Private Sub setEnabled(ByRef menustrip As MenuStrip)

        Dim i, j, k As Integer
        Dim ms1 As ToolStripMenuItem
        Dim ms2 As ToolStripMenuItem
        Dim ms3 As ToolStripMenuItem
        Dim m1 As ToolStripMenuItem
        Dim m2 As ToolStripMenuItem
        Dim m3 As ToolStripMenuItem

        Dim s1, s2, s3 As String
        For i = 1 To menustrip.Items.Count - 1
            If TypeOf menustrip.Items(i) Is ToolStripTextBox Then
                menustrip.Items(i).Visible = False
                Continue For

            End If
            If TypeOf menustrip.Items(i) Is ToolStripSeparator Then
                menustrip.Items(i).Visible = True
                Continue For

            End If
            m1 = menustrip.Items(i)

            If m1.Text = "Window" Then
                m1.Enabled = True

                For j = 0 To m1.DropDownItems.Count - 1
                    m1.DropDownItems(j).Enabled = True
                Next
                Continue For
            End If
            If m1.DropDownItems.Count > 0 Then
                m1.Enabled = True

            Else
                s1 = Mid(m1.Name.ToString, 4, 5)
                If lbmenu2.Items.IndexOf(s1) >= 0 Then
                    m1.Enabled = True

                Else
                    m1.Enabled = False

                End If
            End If

            For j = 0 To m1.DropDownItems.Count - 1

                If TypeOf m1.DropDownItems(j) Is ToolStripSeparator Then
                    Continue For

                End If
                m2 = m1.DropDownItems(j)
                If m2.DropDownItems.Count > 0 Then
                    m2.Enabled = True

                Else
                    s2 = Mid(m2.Name.ToString, 4, 5)
                    If lbmenu2.Items.IndexOf(s2) >= 0 Then
                        m2.Enabled = True

                    Else
                        m2.Enabled = False

                    End If
                End If
                For k = 0 To m2.DropDownItems.Count - 1

                    If TypeOf m2.DropDownItems(k) Is ToolStripSeparator Then
                        Continue For

                    End If
                    m3 = m2.DropDownItems(k)
                    If m3.DropDownItems.Count > 0 Then
                        m3.Enabled = True

                    Else
                        s3 = Mid(m3.Name.ToString, 4, 5)
                        If lbmenu2.Items.IndexOf(s3) >= 0 Then
                            m3.Enabled = True

                        Else
                            m3.Enabled = False

                        End If
                    End If
                Next
            Next
        Next

        displayMode = "ENABLE"
    End Sub

    Private Sub setVisible(ByRef menustrip As MenuStrip)

        Dim i, j, k As Integer
        Dim ms1 As ToolStripMenuItem
        Dim ms2 As ToolStripMenuItem
        Dim ms3 As ToolStripMenuItem
        Dim m1 As New MenuItem
        Dim m2 As New MenuItem
        Dim m3 As New MenuItem

        Dim s1, s2, s3 As String
        For i = 1 To menustrip.Items.Count - 1

            If TypeOf menustrip.Items(i) Is ToolStripTextBox Then
                menustrip.Items(i).Visible = False
                Continue For

            End If

            ms1 = menustrip.Items(i)
            If ms1.Text = "Window" Then
                ms1.Visible = True
                ms1.Enabled = True
                Continue For
            End If

            If ms1.DropDownItems.Count > 0 Then
                ms1.Visible = True
            Else
                s1 = Mid(ms1.Name.ToString, 4, 5)
                If lbmenu2.Items.IndexOf(s1) >= 0 Then
                    ms1.Visible = True
                Else
                    ms1.Visible = False
                End If
            End If


            Dim lastseparator1stlayer As Integer = -1
            Dim allinvisible1stlayerbtw2separator As Boolean = True
            Dim allinvisible As Boolean = True
            For j = 0 To ms1.DropDownItems.Count - 1
                If TypeOf ms1.DropDownItems(j) Is ToolStripMenuItem Then
                    ms2 = ms1.DropDownItems(j)

                    If ms2.DropDownItems.Count > 0 Then
                        Dim lastseparator2ndlayer As Integer = -1
                        Dim allinvisible2ndlayerbtw2separator As Boolean = True
                        Dim allinvisible2ndlayer As Boolean = True

                        For k = 0 To ms2.DropDownItems.Count - 1
                            If TypeOf ms2.DropDownItems(k) Is ToolStripMenuItem Then
                                ms3 = ms2.DropDownItems(k)
                                s3 = Mid(ms3.Name.ToString, 4, 5)
                                If lbmenu2.Items.IndexOf(s3) >= 0 Then
                                    ms3.Visible = True
                                    allinvisible2ndlayerbtw2separator = False
                                    allinvisible2ndlayer = False
                                Else
                                    ms3.Visible = False
                                End If

                            ElseIf TypeOf ms2.DropDownItems(k) Is ToolStripSeparator Then
                                If allinvisible2ndlayerbtw2separator Then
                                    ms2.DropDownItems(k).Visible = False
                                Else
                                    lastseparator2ndlayer = k
                                End If
                                allinvisible2ndlayerbtw2separator = True

                            End If

                        Next

                        If allinvisible2ndlayerbtw2separator And lastseparator2ndlayer > -1 And ms2.DropDownItems.Count > 0 Then
                            ms2.DropDownItems(lastseparator2ndlayer).Visible = False
                        End If
                        If allinvisible2ndlayer = False Then

                            ms2.Visible = True
                            allinvisible1stlayerbtw2separator = False
                            allinvisible = False
                        Else
                            ms2.Visible = False
                        End If
                    Else
                        s2 = Mid(ms2.Name.ToString, 4, 5)
                        If lbmenu2.Items.IndexOf(s2) >= 0 Then
                            ms2.Visible = True
                            allinvisible1stlayerbtw2separator = False
                            allinvisible = False
                        Else
                            ms2.Visible = False
                        End If
                    End If
                ElseIf TypeOf ms1.DropDownItems(j) Is ToolStripSeparator Then
                    If allinvisible1stlayerbtw2separator Then
                        ms1.DropDownItems(j).Visible = False
                    Else
                        lastseparator1stlayer = j
                    End If
                    allinvisible1stlayerbtw2separator = True
                End If
            Next
            If allinvisible1stlayerbtw2separator And lastseparator1stlayer > -1 And ms1.DropDownItems.Count > 0 Then
                ms1.DropDownItems(lastseparator1stlayer).Visible = False
            End If
            If allinvisible = True Then
                ms1.Visible = False
            End If

        Next
        displayMode = "VISIBLE"
    End Sub
    Private Sub setLongName(ByRef menustrip As MenuStrip)
        If curFormNameMode = "SHORT" Or curFormNameMode = "INIT" Then
            'setshortname
            curFormNameMode = "LONG"
            Dim i, j, k As Integer
            'Dim rs_SYUSRGRP As New DataSet
            Dim ms1 As ToolStripMenuItem
            Dim ms2 As ToolStripMenuItem
            Dim ms3 As ToolStripMenuItem
            Dim m1 As ToolStripMenuItem
            Dim m2 As ToolStripMenuItem
            Dim m3 As ToolStripMenuItem

            Dim s1, s2, s3 As String
            For i = 1 To menustrip.Items.Count - 1
                If TypeOf menustrip.Items(i) Is ToolStripTextBox Then
                    Continue For
                End If
                If TypeOf menustrip.Items(i) Is ToolStripSeparator Then
                    Continue For
                End If

                m1 = menustrip.Items(i)

                If m1.Text = "Window" Then
                    Continue For
                End If
                If m1.DropDownItems.Count > 0 Then
                Else
                    If Not Split(m1.Text, " - ")(0).Contains("x") Then

                        m1.Text = Mid(m1.Text, 1, 3) + "000" + Mid(m1.Text, 4, m1.Text.Length - 3)
                    End If
                End If

                For j = 0 To m1.DropDownItems.Count - 1

                    If TypeOf m1.DropDownItems(j) Is ToolStripSeparator Then
                        Continue For
                    End If
                    m2 = m1.DropDownItems(j)
                    If m2.DropDownItems.Count > 0 Then

                    Else
                        If Not Split(m2.Text, " - ")(0).Contains("x") Then

                            m2.Text = Mid(m2.Text, 1, 3) + "000" + Mid(m2.Text, 4, m2.Text.Length - 3)
                        End If
                    End If
                    For k = 0 To m2.DropDownItems.Count - 1

                        If TypeOf m2.DropDownItems(k) Is ToolStripSeparator Then
                            Continue For

                        End If
                        m3 = m2.DropDownItems(k)
                        If m3.DropDownItems.Count > 0 Then

                        Else
                            If Not Split(m3.Text, " - ")(0).Contains("x") Then
                                m3.Text = Mid(m3.Text, 1, 3) + "000" + Mid(m3.Text, 4, m3.Text.Length - 3)
                            End If

                        End If
                    Next
                Next
            Next

        End If
    End Sub

    Private Sub setShortName(ByRef menustrip As MenuStrip)
        If curFormNameMode = "LONG" Then
            'setshortname
            curFormNameMode = "SHORT"
            Dim i, j, k As Integer
            'Dim rs_SYUSRGRP As New DataSet
            Dim ms1 As ToolStripMenuItem
            Dim ms2 As ToolStripMenuItem
            Dim ms3 As ToolStripMenuItem
            Dim m1 As ToolStripMenuItem
            Dim m2 As ToolStripMenuItem
            Dim m3 As ToolStripMenuItem

            Dim s1, s2, s3 As String
            For i = 1 To menustrip.Items.Count - 1
                If TypeOf menustrip.Items(i) Is ToolStripTextBox Then
                    Continue For
                End If
                If TypeOf menustrip.Items(i) Is ToolStripSeparator Then
                    Continue For
                End If

                m1 = menustrip.Items(i)

                If m1.Text = "Window" Then
                    Continue For
                End If
                If m1.DropDownItems.Count > 0 Then
                    'do nothing
                Else
                    If Not Split(m1.Text, " - ")(0).Contains("x") Then

                        m1.Text = Mid(m1.Text, 1, 3) + Mid(m1.Text, 7, m1.Text.Length - 6)
                    End If
                End If

                For j = 0 To m1.DropDownItems.Count - 1

                    If TypeOf m1.DropDownItems(j) Is ToolStripSeparator Then
                        Continue For

                    End If
                    m2 = m1.DropDownItems(j)
                    If m2.DropDownItems.Count > 0 Then
                        'do nothing
                    Else
                        If Not Split(m2.Text, " - ")(0).Contains("x") Then

                            m2.Text = Mid(m2.Text, 1, 3) + Mid(m2.Text, 7, m2.Text.Length - 6)
                        End If
                    End If
                    For k = 0 To m2.DropDownItems.Count - 1

                        If TypeOf m2.DropDownItems(k) Is ToolStripSeparator Then
                            Continue For

                        End If
                        m3 = m2.DropDownItems(k)
                        If m3.DropDownItems.Count > 0 Then
                            'do nothing
                        Else
                            If Not Split(m3.Text, " - ")(0).Contains("x") Then

                                m3.Text = Mid(m3.Text, 1, 3) + Mid(m3.Text, 7, m3.Text.Length - 6)
                            End If
                        End If
                    Next
                Next
            Next

        End If
    End Sub

    Private Sub setDropDownFit(ByRef menustrip As MenuStrip)

    End Sub

    Private Sub SetMuneMode(ByVal usr As String)
        Dim rs_syusrpr As DataSet
        Dim mode As String
        gspStr = "sp_list_SYUSRPRF_1 '" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_syusrpr, rtnStr)
        Dim Old_Menu_Enable_Style As Int16 = 1
        Dim Old_Menu_Visible_Style As Int16 = 2
        Dim New_Menu_Enable_Style As Int16 = 3
        Dim New_Menu_Visible_Style As Int16 = 4
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYS00002 sp_list_SYUSRPRF_1 : " & rtnStr)
        Else
            Dim dtr() As DataRow
            dtr = rs_syusrpr.Tables("RESULT").Select("yup_usrid = '" & gsUsrID & "'")
            mode = dtr(0).Item("yup_displaymode")
            Select Case mode
                Case Old_Menu_Enable_Style
                    oldMenuEnabledStyle()
                Case Old_Menu_Visible_Style
                    oldMenuVisibleStyle()
                Case New_Menu_Enable_Style
                    newMenuEnabledStyle()
                Case Else '"New Menu (Visible) Style"
                    newMenuVisibleStyle()
            End Select
        End If

    End Sub



    Private Sub timeout_Trigger()
        timeout.Enabled = False
        Dim timeout_Unlock As New ERP00002
        timeout_Unlock.BringToFront()
        timeout_Unlock.ShowDialog(Me)
        timeout_Unlock = Nothing
        timeout.Interval = timeout_tick
        timeout.Interval = timeout_max
        timeout.Enabled = True
    End Sub

    Private Sub timeout_Reset_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        timeout.Interval = timeout_tick
        timeout.Interval = timeout_max
        timeout.Enabled = True
    End Sub

    'Private Sub miReLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'SkipExitMsg = True

    '    Dim reLogin As New ERP00001
    '    reLogin.Show()
    '    Me.Close()
    '    reLogin = Nothing
    'End Sub
    Private Sub menu_log(ByVal menu As String)
        'gspStr = "sp_insert_menulog "
    End Sub


    Private Sub ERP00000_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Owner.Close()
    End Sub

    'Private Sub miSHM00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSHR00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYS00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00014_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00015_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00017_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miINR00014_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miDYR00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCLM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00104_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYS00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If checkFormLoaded(sender) = False Then
    '    '    sc112.Panel2.Controls.Add(showFormInPanel(sender, Me))
    '    'End If
    '    'bringFormLoaded(sender)


    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYS00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCLM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCLR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCLR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYR00103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00105_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00106_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00107_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miFQM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00011_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00016_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00023_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00026_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMXLS005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00018_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMM00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMXLS001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMM00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If checkFormLoaded(sender) = False Then
    '    '    Dim f As Form
    '    '    f = showFormInPanel(sender, Me)
    '    '    sc112.Panel2.Controls.Add(f)
    '    '    f.Parent = sc112.Panel2
    '    'End If
    '    'bringFormLoaded(sender)

    '    'showForm(sender, Me)
    'End Sub

    Private Function checkFormLoaded(ByVal mnuItem As MenuItem) As Boolean
        'Dim formName As String = Split(CType(mnuItem, MenuItem).Text.ToString, " - ")(0).Trim
        'Dim formLoaded As Boolean
        'formLoaded = False
        'Dim i As Integer
        'For i = 0 To sc112.Panel2.Controls.Count - 1
        '    If sc112.Panel2.Controls(i).Name = formName Then
        '        formLoaded = True
        '    End If
        'Next
        'Return formLoaded
    End Function

    Private Sub bringFormLoaded(ByVal mnuItem As MenuItem)
        'Dim formName As String = Split(CType(mnuItem, MenuItem).Text.ToString, " - ")(0).Trim
        'Dim i As Integer
        'For i = 0 To sc112.Panel2.Controls.Count - 1
        '    If sc112.Panel2.Controls(i).Name = formName Then
        '        sc112.Panel2.Controls(i).BringToFront()
        '    End If
        'Next
    End Sub


    'Private Sub miIMXLS007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIAR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00035_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00034_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00017_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00032_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMG00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMG00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSCM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSCR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSCM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSHR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSCR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00025_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00026_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00029_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00030_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00031_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00032_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00024_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQUM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSAM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSAM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSAM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSAM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSAR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSAR00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSAR00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQUM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub imPOM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSHR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miBOM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCUM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQUR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMXLS004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPOR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPOR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPOR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPOR00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miBOR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCUM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miVNM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00028_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQUR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQUXLS001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCUM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miTOM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miTOM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miTOM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miTOM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSAM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSCM00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miTOM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MenuItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00029_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miBJR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miFTY00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miFTY00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00023_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00027_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00021_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00022_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00019_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00020_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00022_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00031_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00033_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00019_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCOR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00031_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00108_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miINR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPKR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miACR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00011_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGM00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCLR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miCLR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub


    'Private Sub miIMM00015_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub


    'Private Sub miMSR00035_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSHM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00030_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSHM00110_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSHR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00027_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00036_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miRIR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00109_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSHM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPO00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPO00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPO00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPR0002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMPR00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMIM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMIM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00020_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPCM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSMR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSMR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miBSP00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miINR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miINR00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miINR00011_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miINR00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miINR00013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miMSR00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub


    'Private Sub miMSR00008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSCR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQCM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQCM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQCM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQCM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQCM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQCM00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00130_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQCM00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub


    'Private Sub miPGM00013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub


    'Private Sub miPGXLS001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miPGR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miQCM00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00131_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miIMR00036_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub miSYM00032_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    Private Sub RightMenuBarOnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sc1.Panel2Collapsed = False Then
        '    sc1.Panel2Collapsed = True
        '    RightMenuBarOnToolStripMenuItem.Text = "Right Menu Bar - Off"
        'Else
        '    sc1.Panel2Collapsed = False
        '    RightMenuBarOnToolStripMenuItem.Text = "Right Menu Bar - On"
        'End If
    End Sub

    Private Sub LeftMenuBarOnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sc11.Panel1Collapsed = False Then
        '    sc11.Panel1Collapsed = True
        '    LeftMenuBarOnToolStripMenuItem.Text = "Left Menu Bar - Off"
        'Else
        '    sc11.Panel1Collapsed = False
        '    LeftMenuBarOnToolStripMenuItem.Text = "Left Menu Bar - On"
        'End If
    End Sub

    Private Sub TopMenuBarERPOnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopMenuBarERPOnToolStripMenuItem.Click
        If msMenuERP.Visible = False Then
            msMenuERP.Visible = True
            msMenuERP.BringToFront()
            TopMenuBarERPOnToolStripMenuItem.Text = "Top Menu Bar (ERP) - On"
        Else
            msMenuERP.Visible = False
            TopMenuBarERPOnToolStripMenuItem.Text = "Top Menu Bar (ERP) - Off"
        End If


    End Sub


    Private Sub TopMenuBarMainOnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopMenuBarMainOnToolStripMenuItem.Click
        'If msMenu.Visible = False Then
        '    msMenu.Visible = True
        '    msMenu.BringToFront()
        '    TopMenuBarMainOnToolStripMenuItem.Text = "Top Menu Bar (Main) - On"
        'Else
        '    msMenu.Visible = False
        '    TopMenuBarMainOnToolStripMenuItem.Text = "Top Menu Bar (Main) - Off"
        'End If
    End Sub

    Private Sub DocumentDiagramOnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sc112.Panel1Collapsed = False Then
        '    sc112.Panel1Collapsed = True
        '    DocumentDiagramOnToolStripMenuItem.Text = "Document Diagram - Off"
        'Else
        '    sc112.Panel1Collapsed = False
        '    DocumentDiagramOnToolStripMenuItem.Text = "Document Diagram - On"
        'End If
    End Sub

    'Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub sc12_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    'End Sub

    'Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If ListView1.ShowGroups = False Then
    '    '    ListView1.ShowGroups = True
    '    'Else
    '    '    ListView1.ShowGroups = False
    '    'End If

    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If ListView1.View = View.Details Then
    '    '    ListView1.View = View.LargeIcon
    '    '    Button2.Text = "LargeIcon"
    '    'ElseIf ListView1.View = View.LargeIcon Then
    '    '    ListView1.View = View.List
    '    '    Button2.Text = "List"
    '    'ElseIf ListView1.View = View.List Then
    '    '    ListView1.View = View.SmallIcon
    '    '    Button2.Text = "SmallIcon"
    '    'ElseIf ListView1.View = View.SmallIcon Then
    '    '    ListView1.View = View.Tile
    '    '    Button2.Text = "Tile"
    '    'ElseIf ListView1.View = View.Tile Then
    '    '    ListView1.View = View.Details
    '    '    Button2.Text = "Details"


    '    'End If

    'End Sub

    'Private Sub DocumentDiagramToolStripStatusLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If sc112.Panel1Collapsed = False Then
    '    '    sc112.Panel1Collapsed = True
    '    '    DocumentDiagramToolStripStatusLabel.Text = "Document Diagram - Off"
    '    'Else
    '    '    sc112.Panel1Collapsed = False
    '    '    DocumentDiagramToolStripStatusLabel.Text = "Document Diagram - On"
    '    'End If
    'End Sub

    'Private Sub RightMenuToolStripStatusLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If sc1.Panel2Collapsed = False Then
    '    '    sc1.Panel2Collapsed = True
    '    '    RightMenuToolStripStatusLabel.Text = "Right Menu Bar - Off"
    '    'Else
    '    '    sc1.Panel2Collapsed = False
    '    '    RightMenuToolStripStatusLabel.Text = "Right Menu Bar - On"
    '    'End If
    'End Sub

    'Private Sub LeftMenuToolStripStatusLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If sc11.Panel1Collapsed = False Then
    '    '    sc11.Panel1Collapsed = True
    '    '    LeftMenuToolStripStatusLabel.Text = "Left Menu Bar - Off"
    '    'Else
    '    '    sc11.Panel1Collapsed = False
    '    '    LeftMenuToolStripStatusLabel.Text = "Left Menu Bar - On"
    '    'End If
    'End Sub


    'Private Sub msMenu_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    'End Sub


    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    WindowToolStripMenuItem.Enabled = True
    'End Sub

    'Private Sub menuButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMXLS001ItemExcelFileUploadInteralJointVentureItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMM00002ItemMasterApprovalRejectionInternalJointVentureItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMM00013ItemMasterInvalidItemReactivationInternalJointVentureItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00004ItemValidationReportInternalJointVentureItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00005ExcelFileSearchReportInternalJointVentureItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00034ItemMasterReportExportInternalJointVentureItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMXLS005ItemExcelFileUploadExternalItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMM00012ItemMasterApprovalRejectionExternalItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00018ItemValidationReportExternalItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMM00015ItemMasterDataExportExternalItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMG00001ItemMasterImageUploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMG00002ItemMasterImageUploadExternalItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub CUM00001CustomerMasterMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub CUM00002CustomerItemHistoryOldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub CUM00003CustomerItemHistoryNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub VNM00001VendorMasterMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00102TradingTermMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00103VendorTradingTermSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYR00103VendorTradingTermsListReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QUM00001QuotationMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QUAPP001QuotationAppsApprovalRejectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QUM00004PDAQuotationApproveRejectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QUR00001PrintQuotationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QUR00003ExportQuotationToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QUXLS001UploadQuotationExcelToERPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMXLSx004CustomerStyleNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMRx00010ItemValidationReportCustomerStyleNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub RIR00001ReQuoteItemListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SAM00004SampleRequestGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SAM00001SampleRequestMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SAM00002SampleOrderSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SAM00003SampleInvoiceInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SAM00005SampleInvoiceGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SAR00005SampleInvoiceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SAR00006SampleRequestReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SAR00007PackingListReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub TOM00002TentativeOrderGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub TOM00001TentativeOrderMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub TOM00003TenetaiveOrderReleaseUnReleaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub TOM00004TentativeOrderHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub TOM00005ExportTentativeToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SCM00001SalesConfirmationMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SCM00004TransportShipmarkMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SHR00002ReleaseUnreleaseSalesConfirmationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SCM00003SCFactoryDataApprovalRejecctionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SCM00006SCApprovalRejectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SCR00001PrintSalesConfirmationReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SCR00003PrintCancellationSCWithBOMItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00009PrintProductLabelListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00024AttachmentUpdateHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00025MOQSCRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00026MOQOutstandingRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00029FactoryApproveDataComparisonReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00030FactoryApproveDataBatchReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00031SalesConfirmationListToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00036SalesConfirmationListToExcelCheckDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00032LateShipmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub POR00001PurchaseOrderReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub POR00003BOMPurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub POR00005PrintProductionNoteJobOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub POR00007BOMPOReportExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub BOR00001VendorPurchaseReportBOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub POM00010PurchaseOrderApprovalMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SHM00001ShippingMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00030ShippingCustomerSelfdefinedMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SHM00002CreditDebitNoteInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00109ShippingForwarderMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SHM00010ShippingChargesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub INR00001PrintInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PKR00001PrintPackingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SHR00010PrintShippingChargesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00009PrintInvoiceSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00027PrintContainerSearchReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00036PrintContainerSummeryReportByCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00031PackagingComponentMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00001PackagingItemMasterMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem137_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00003ReleaseUnreleasePackagingRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGXLS001ExcelUploadForPackagingRequestGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGR00001PackagingRequestInformationExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00005PackagingOrderGenerationAndUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00004PackagingOrderMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00008ReleaseUnreleasePackagingOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00009PackagingOrderCreationLabelHangtagToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00006PackagingOrderApprovalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00011PackagingOrderApprovalReadOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00012PackagingAnalysisReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00013PackagingOrderCostComparsionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PGM00007PrintPackagingOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub BOM00001BOMOrderMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SHR00003ReleaseUnreleasePurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub POM00001PurchaseOrderMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00104ClaimsCategoryMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00108ClaimsCurrencyMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub CLM00001ClaimsTransactionMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub CLR00004ClaimsAnalysisReportAccountFormatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub CLR00005ClaimsAnalysisReportSummaryListFormatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub CLR00001PrintClaimsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub PCM00001AccountSetupMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00032CurrencyMaintenanceAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub ACR00001LAIFEIAnalysisReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SMR00001ShipmentMatchingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SMR00002ShipmentMatchingReportSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub BJR00001BatchJobGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub FTY00001PDOSystemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub FTY00004PDODocumentHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPM00001ManufacturingPurchaseOrderMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPM00002GRNTransferMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPM00003SupplierDeliveryMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPO00001WTManufacturingPurchaseOrderSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPO00002WTManufacturingPurchaseOrderGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPO00003WTManufacturingPurchaseOrderApprovalRejectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPR00001WTManufacturingPurchaseOrderExceptionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPR00002PrintManufacturingPurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPR00002PrintManufacturingPurchaseOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPR00004MPOItemMasterListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPR00005GRNTransactionListAdhocMiscTypeOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MPR00006MPRTransactionStatisticsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MIM00001WTFactoryItemMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MIM00002ItemMasterApprovalRejectionWTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00020PRCItemCategoryMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00130SZSalesTeamMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SYM00131AQLMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QCM00001QCInspectionRequestGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QCM00002QCInspectionRequestMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QCM00003ReleaseUnreleaseQCInspectionRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QCM00004QCInspectionRequestSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QCM00009QCAttachmentMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QCM00005QCInspectionRequestListSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QCM00006QCInspectionRequestCheckListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub QCM00007QCReportHistorySummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IAR00001ImpactAnalysisReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00017ItemPricingReportExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00032DocumentListByItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00013ItemImageAnalystReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00013ItemImageAnalystReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00027ExportItemImageToExcelwithBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00021AssortedItemListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00022CustomerAliasItemListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub INR00014CBMReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00002QuotationIndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00019SalesConfirmationIndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00020PurchaseOrderIndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00022BOMPOIndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00031InvoiceIndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00033SampleInvoiceIndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00001OutstandingReportBySalesConfirmationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00004OutstandingReportByVendorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00012OutstandingReportByCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00005OutstandingReportByPurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00035OutstandingReportShippingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub IMR00019ExternalItemImageListExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub INR00011SCSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub SCR00002SalesConfirmationAnalysisReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00007CustomerItemHistoryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub BSP00004SalesAnalysisByDesignerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub INR00004ProductionCapacityInCBMReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub INR00010CBMOrderedReportFactoryShipDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub INR00013ShippingSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub INR00012ShippingScheduleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub MSR00008MonthlyStatementForSampleChargesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub DYR00001VwCIHRepoortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub SYM33ShippingChargesFormulaSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem219_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem220_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem221_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem222_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem223_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem224_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem225_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem226_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem227_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem228_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem229_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem231_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem232_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem233_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem234_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem68_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem74_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem76_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem77_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem78_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem85_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem86_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem87_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem88_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem89_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem92_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem93_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem94_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem95_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem96_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem104_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem105_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem106_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem107_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem112_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem113_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem115_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem116_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem117_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem118_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem119_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem125_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem126_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem127_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem128_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem129_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem130_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem131_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem132_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem133_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem134_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem135_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem142_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem143_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem144_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem145_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem146_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem147_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem148_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem149_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem150_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem151_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem152_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem153_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem154_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem156_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem157_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem163_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem164_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub ToolStripMenuItem165_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub

    'Private Sub CLR00001PrintClaimsReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm2(sender, Me)
    'End Sub


    Private Sub smiReLegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiReLegin.Click

        Dim reLogin As New ERP00001
        reLogin.Show()
        Me.Close()
        reLogin = Nothing
    End Sub

    Private Sub smiSYS01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYS01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYS02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYS02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYS03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYS03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYS04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYS04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM02.Click
        showForm2(sender, Me)
    End Sub


    Private Sub smiSYM03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM06.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM08.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM09.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM10.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM11.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM12.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM13.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM14.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM15.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM16.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM17.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM23.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM26.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM28.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM29.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM33.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMM04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMM04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMX07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMX07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR35.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMX01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMX01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMM13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMM13.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR34.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMX05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMX05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMM12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMM12.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR18.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMM15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMM15.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMG01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMG01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMG02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMG02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiCUM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiCUM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiCUM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiCUM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiCUM03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiCUM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub ToolStripMenuItem337_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiVNM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQUM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQUM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQUA01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQUA01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQUM04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQUM04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQUR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQUR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQUX01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQUX01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQUR03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQUR03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiRIR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiRIR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSAM04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSAM04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSAM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSAM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSAM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSAM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSAM03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSAM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSAM05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSAM05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSAR05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSAR05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSAR06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSAR06.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSAR07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSAR07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiTOM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiTOM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiTOM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiTOM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiTOM03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiTOM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiTOM04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiTOM04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiTOM05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiTOM05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSCM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSCM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSCM04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSCM04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSHR02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSCM07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSCM03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSCM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSCM06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSCM06.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSCR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSCR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSCR03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSCR03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR09.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR24.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR25.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR26.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR29.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR30.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR31.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR36.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR32.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPOM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPOM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSHR503_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPOM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiBOM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiBOM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPOR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPOR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPOR03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPOR03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPOR05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPOR05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPOR07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPOR07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiBOR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiBOR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPOM10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPOM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSHM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSHM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM30.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSHM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSHM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub ToolStripMenuItem397_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM36.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSHM10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSHM07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiINR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiINR01.Click
        showForm2(sender, Me)
    End Sub


    Private Sub smiPKR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPKR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSHR10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSHR10.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR09.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR27.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR36.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM31.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGX01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGX01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM08.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM09.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiPGM06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiPGM06.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM11.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM12.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiPGM13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiPGM13.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiPGM07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiPGM07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiCLM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiCLM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiCLR04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiCLR04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiCLR05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiCLR05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiCLR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiCLR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiPCM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiPCM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiSYM32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiSYM32.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiACR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiACR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSMR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSMR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSMR02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSMR02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiBJR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiBJR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiFTY01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiFTY01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiFTY04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiFTY04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPM03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPO01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPO01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPO02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPO02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPO03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPO03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPR02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPR02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPR03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPR03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPR04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPR04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPR05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPR05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMPR06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMPR06.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMIM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMIM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMIM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMIM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM20.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQCM01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQCM01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQCM02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQCM02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQCM03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQCM03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQCM04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQCM04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQCM09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQCM09.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQCM05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQCM05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQCM06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQCM06.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiQCM07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiQCM07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIAR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIAR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR17.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR32.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR13.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR23.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR27.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR21.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiIMR22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiIMR22.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiINR14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiINR14.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR19.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR20.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR22.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR31.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR33.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiMSR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiMSR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiMSR04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiMSR04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiMSR12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiMSR12.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiMSR05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiMSR05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiMSR35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiMSR35.Click
        showForm2(sender, Me)
    End Sub

    Private Sub msiIMR19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msiIMR19.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiINR11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiINR11.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSCR02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSCR02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiBSP04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiBSP04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiINR04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiINR04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiINR10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiINR10.Click
        showForm2(sender, Me)
    End Sub

    Private Sub ToolStripMenuItem499_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiINR13.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiINR12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiINR12.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiMSR08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiMSR08.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR01.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR02.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR03.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR04.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR05.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR06.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR07.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR08.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR09.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiDYR10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiDYR10.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiCOR01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiCOR01.Click
        showForm2(sender, Me)
    End Sub

    'Private Sub SYM00033ShippingChargesFormulaSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    'Private Sub COR00001AuditTrailReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    showForm(sender, Me)
    'End Sub

    Private Sub smiSYM37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM37.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM38.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM39.Click
        showForm2(sender, Me)
    End Sub

    Private Sub smiSYM40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiSYM40.Click
        showForm2(sender, Me)
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        resetAllMenuItem(Me.msMenuERP)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        resetAllMenuItem(Me.msMenuERP)
        setEnabled(Me.msMenuERP)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        resetAllMenuItem(Me.msMenuERP)
        setVisible(Me.msMenuERP)
    End Sub

    Private Sub btnToLong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToLong.Click
        setLongName(Me.msMenuERP)
    End Sub


    Private Sub btnToShort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToShort.Click
        setShortName(Me.msMenuERP)
    End Sub

    Private Sub autosetMenuWidth(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TypeOf sender Is ToolStripMenuItem Then

            Dim j As Integer = 0
            Dim Size As SizeF

            Dim senderMenuItem As ToolStripMenuItem
            senderMenuItem = sender
            Dim g As Graphics = senderMenuItem.DropDown.CreateGraphics()
            Dim maxlength As Double = 0
            Dim s1, s2, s3 As String
            For j = 0 To senderMenuItem.DropDownItems.Count - 1
                If TypeOf senderMenuItem.DropDownItems(j) Is ToolStripMenuItem Then
                    Dim ms1 As ToolStripMenuItem
                    ms1 = senderMenuItem.DropDownItems(j)
                    s1 = Mid(ms1.Name.ToString, 4, 5)
                    If (lbmenu2.Items.IndexOf(s1) >= 0 And displayMode = "VISIBLE") Or displayMode = "ENABLE" Then

                        Size = g.MeasureString(senderMenuItem.DropDownItems(j).Text, senderMenuItem.DropDownItems(j).Font)

                        If (Size.Width > maxlength) Then
                            maxlength = Size.Width

                        End If
                    End If
                End If
            Next
            senderMenuItem.DropDown.AutoSize = False
            senderMenuItem.DropDown.Width = 0.979 * maxlength + 70
            'You may wonder what is '0.979 * maxlength + 70'. This is the formula
            'between the string length and the dropdown width I find out.
            'Yea, I just try several string and get the dropdown, then ask excel to find it.

            For j = 0 To senderMenuItem.DropDownItems.Count - 1
                If TypeOf senderMenuItem.DropDownItems(j) Is ToolStripMenuItem Then

                    Dim ms1 As ToolStripMenuItem
                    ms1 = senderMenuItem.DropDownItems(j)
                    ms1.AutoSize = False
                    ms1.Width = 0.979 * maxlength + 68
                End If
            Next
            senderMenuItem.DropDown.Refresh()
            senderMenuItem.DropDown.ResumeLayout()

        End If
    End Sub

    Private Sub autosetMenuHeight(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TypeOf sender Is ToolStripMenuItem Then

            Dim j As Integer = 0

            Dim senderMenuItem As ToolStripMenuItem
            senderMenuItem = sender
            Dim height As Double = 0
            Dim s1, s2, s3 As String
            For j = 0 To senderMenuItem.DropDownItems.Count - 1
                If TypeOf senderMenuItem.DropDownItems(j) Is ToolStripMenuItem Then
                    Dim ms1 As ToolStripMenuItem
                    ms1 = senderMenuItem.DropDownItems(j)
                    s1 = Mid(ms1.Name.ToString, 4, 5)
                    If (lbmenu2.Items.IndexOf(s1) >= 0 And displayMode = "VISIBLE") Or displayMode = "ENABLE" Then
                        height = height + senderMenuItem.DropDownItems(j).Height
                    End If
                End If
                If TypeOf senderMenuItem.DropDownItems(j) Is ToolStripSeparator Then
                    If senderMenuItem.DropDownItems(j).Visible = True Then
                        'why dont this function(autosetMenuHeight) put at 'opening' event? 
                        'It is because the visible property of senderMenuItem.DropDownItems(j)
                        'is false in DropDown opening phase...or socall before open DropDown.
                        '(Key word : Leaky abstraction)
                        height = height + senderMenuItem.DropDownItems(j).Height

                    End If
                End If
            Next
            senderMenuItem.DropDown.AutoSize = False
            senderMenuItem.DropDown.Height = height + 4
            senderMenuItem.DropDown.Refresh()

        End If
    End Sub



    Private Sub ToolStripTextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ToolStripTextBox2.KeyPress
        'If e.KeyChar = Chr(13) Then

        '    showFormbyCode(ToolStripTextBox2.Text, Me)
        '    ToolStripTextBox2.Text = ""
        'End If
    End Sub

    Private Sub oldMenuVisibleStyle()
        resetAllMenuItem(Me.msMenuERP)
        '1.visible mod
        setVisible(Me.msMenuERP)
        '2.set full form
        setLongName(Me.msMenuERP)
    End Sub


    Private Sub newMenuEnabledStyle()
        resetAllMenuItem(Me.msMenuERP)
        '1.visible mod
        setEnabled(Me.msMenuERP)
        '2.set short form
        setShortName(Me.msMenuERP)
    End Sub

    Private Sub newMenuVisibleStyle()
        resetAllMenuItem(Me.msMenuERP)
        '1.visible mod
        setVisible(Me.msMenuERP)
        '2.set short form
        setShortName(Me.msMenuERP)
    End Sub

    Private Sub oldMenuEnabledStyle()
        resetAllMenuItem(Me.msMenuERP)
        '1.visible mod
        setEnabled(Me.msMenuERP)
        '2.set full form
        setLongName(Me.msMenuERP)
    End Sub

    Private Sub btnOldEnableStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOldEnableStyle.Click
        oldMenuEnabledStyle()
    End Sub

    Private Sub btnOldVisibleStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOldVisibleStyle.Click
        oldMenuVisibleStyle()
    End Sub

    Private Sub btnNewMenuEnableStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewMenuEnableStyle.Click
        newMenuEnabledStyle()
    End Sub

    Private Sub btnNewVisibleStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewVisibleStyle.Click
        newMenuVisibleStyle()
    End Sub

    Private Sub MenuBarSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBarSetup.Click

    End Sub
End Class
