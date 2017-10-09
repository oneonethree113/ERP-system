Public Class ERP00000
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
    Friend WithEvents mmMenu As System.Windows.Forms.MainMenu
    Friend WithEvents miFile As System.Windows.Forms.MenuItem
    Friend WithEvents miReLogin As System.Windows.Forms.MenuItem
    Friend WithEvents miExit As System.Windows.Forms.MenuItem
    Friend WithEvents miSystem As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYS00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYS00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miItem As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00101 As System.Windows.Forms.MenuItem
    Friend WithEvents lbMenu As System.Windows.Forms.ListBox
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents miSHM00010 As System.Windows.Forms.MenuItem
    Friend WithEvents miSHR00010 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00007 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00010 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00013 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00014 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00015 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00017 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miINR00014 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00006 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00007 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00008 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00009 As System.Windows.Forms.MenuItem
    Friend WithEvents miDYR00010 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents miCLM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00102 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00103 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00104 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYS00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYS00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents miCLR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYR00103 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00006 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00008 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00009 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00011 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00012 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00016 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00023 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00026 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMXLS005 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00018 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00012 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMXLS001 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00013 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00035 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMXLS007 As System.Windows.Forms.MenuItem
    Friend WithEvents miIAR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00034 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00017 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00032 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMG00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMG00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSCR00003 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents miSCR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00009 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00024 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00025 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00026 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00029 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00030 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00031 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00032 As System.Windows.Forms.MenuItem
    Friend WithEvents miQUM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSCM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSCM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miSHR00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miSCM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAR00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAR00006 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAR00007 As System.Windows.Forms.MenuItem
    Friend WithEvents miQUM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents imPOM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSHR00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miBOM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miCUM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents miQUR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMXLS004 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00010 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents miPOR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miPOR00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miPOR00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miPOR00007 As System.Windows.Forms.MenuItem
    Friend WithEvents miBOR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents miCUM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miVNM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00028 As System.Windows.Forms.MenuItem
    Friend WithEvents miQUR00003 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents miQUXLS001 As System.Windows.Forms.MenuItem
    Friend WithEvents miCUM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAM00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miSCM00006 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00005 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00029 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents miBJR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miFTY00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miFTY00004 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00013 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00023 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00027 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00021 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00022 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00019 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00020 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00022 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00031 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00033 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00012 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00019 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents miCOR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem41 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00031 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem48 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00008 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem52 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00009 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem54 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00006 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem57 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00007 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00108 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents miINR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miPKR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miPOM00010 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ERP00000))
        Me.mmMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.miFile = New System.Windows.Forms.MenuItem
        Me.miReLogin = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.miExit = New System.Windows.Forms.MenuItem
        Me.miSystem = New System.Windows.Forms.MenuItem
        Me.miSYS00001 = New System.Windows.Forms.MenuItem
        Me.miSYS00002 = New System.Windows.Forms.MenuItem
        Me.miSYS00003 = New System.Windows.Forms.MenuItem
        Me.miSYS00004 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.miSYM00001 = New System.Windows.Forms.MenuItem
        Me.miSYM00002 = New System.Windows.Forms.MenuItem
        Me.miSYM00003 = New System.Windows.Forms.MenuItem
        Me.miSYM00004 = New System.Windows.Forms.MenuItem
        Me.miSYM00005 = New System.Windows.Forms.MenuItem
        Me.miSYM00006 = New System.Windows.Forms.MenuItem
        Me.miSYM00007 = New System.Windows.Forms.MenuItem
        Me.miSYM00008 = New System.Windows.Forms.MenuItem
        Me.miSYM00009 = New System.Windows.Forms.MenuItem
        Me.miSYM00010 = New System.Windows.Forms.MenuItem
        Me.miSYM00011 = New System.Windows.Forms.MenuItem
        Me.miSYM00012 = New System.Windows.Forms.MenuItem
        Me.miSYM00013 = New System.Windows.Forms.MenuItem
        Me.miSYM00014 = New System.Windows.Forms.MenuItem
        Me.miSYM00015 = New System.Windows.Forms.MenuItem
        Me.miSYM00016 = New System.Windows.Forms.MenuItem
        Me.miSYM00017 = New System.Windows.Forms.MenuItem
        Me.miSYM00023 = New System.Windows.Forms.MenuItem
        Me.miSYM00026 = New System.Windows.Forms.MenuItem
        Me.miSYM00028 = New System.Windows.Forms.MenuItem
        Me.miSYM00029 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.miSYM00101 = New System.Windows.Forms.MenuItem
        Me.miItem = New System.Windows.Forms.MenuItem
        Me.miIMM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.miIMXLS007 = New System.Windows.Forms.MenuItem
        Me.miIMR00035 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.miIMXLS001 = New System.Windows.Forms.MenuItem
        Me.miIMM00002 = New System.Windows.Forms.MenuItem
        Me.miIMM00013 = New System.Windows.Forms.MenuItem
        Me.miIMR00004 = New System.Windows.Forms.MenuItem
        Me.miIMR00005 = New System.Windows.Forms.MenuItem
        Me.miIMR00034 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.miIMXLS005 = New System.Windows.Forms.MenuItem
        Me.miIMM00012 = New System.Windows.Forms.MenuItem
        Me.miIMR00018 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.miIMG00001 = New System.Windows.Forms.MenuItem
        Me.miIMG00002 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.miCUM00001 = New System.Windows.Forms.MenuItem
        Me.miCUM00002 = New System.Windows.Forms.MenuItem
        Me.miCUM00003 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.miVNM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.miSYM00102 = New System.Windows.Forms.MenuItem
        Me.miSYM00103 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.miSYR00103 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.miQUM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem33 = New System.Windows.Forms.MenuItem
        Me.miQUM00004 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.miQUR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.miQUXLS001 = New System.Windows.Forms.MenuItem
        Me.miQUR00003 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.miIMXLS004 = New System.Windows.Forms.MenuItem
        Me.miIMR00010 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.miSAM00004 = New System.Windows.Forms.MenuItem
        Me.miSAM00001 = New System.Windows.Forms.MenuItem
        Me.miSAM00002 = New System.Windows.Forms.MenuItem
        Me.miSAM00003 = New System.Windows.Forms.MenuItem
        Me.miSAM00005 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.miSAR00005 = New System.Windows.Forms.MenuItem
        Me.miSAR00006 = New System.Windows.Forms.MenuItem
        Me.miSAR00007 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.miTOM00002 = New System.Windows.Forms.MenuItem
        Me.miTOM00001 = New System.Windows.Forms.MenuItem
        Me.miTOM00003 = New System.Windows.Forms.MenuItem
        Me.miTOM00004 = New System.Windows.Forms.MenuItem
        Me.miTOM00005 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.miSCM00001 = New System.Windows.Forms.MenuItem
        Me.miSCM00004 = New System.Windows.Forms.MenuItem
        Me.miSHR00002 = New System.Windows.Forms.MenuItem
        Me.miSCM00003 = New System.Windows.Forms.MenuItem
        Me.miSCM00006 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.miSCR00001 = New System.Windows.Forms.MenuItem
        Me.miSCR00003 = New System.Windows.Forms.MenuItem
        Me.miIMR00009 = New System.Windows.Forms.MenuItem
        Me.miIMR00024 = New System.Windows.Forms.MenuItem
        Me.miIMR00025 = New System.Windows.Forms.MenuItem
        Me.miIMR00026 = New System.Windows.Forms.MenuItem
        Me.miIMR00029 = New System.Windows.Forms.MenuItem
        Me.miIMR00030 = New System.Windows.Forms.MenuItem
        Me.miIMR00031 = New System.Windows.Forms.MenuItem
        Me.miIMR00032 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.imPOM00001 = New System.Windows.Forms.MenuItem
        Me.miSHR00003 = New System.Windows.Forms.MenuItem
        Me.miBOM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.miPOR00001 = New System.Windows.Forms.MenuItem
        Me.miPOR00003 = New System.Windows.Forms.MenuItem
        Me.miPOR00005 = New System.Windows.Forms.MenuItem
        Me.miPOR00007 = New System.Windows.Forms.MenuItem
        Me.miBOR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem38 = New System.Windows.Forms.MenuItem
        Me.miPOM00010 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.miSHM00010 = New System.Windows.Forms.MenuItem
        Me.miSHR00010 = New System.Windows.Forms.MenuItem
        Me.MenuItem42 = New System.Windows.Forms.MenuItem
        Me.miINR00001 = New System.Windows.Forms.MenuItem
        Me.miPKR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem41 = New System.Windows.Forms.MenuItem
        Me.miSYM00031 = New System.Windows.Forms.MenuItem
        Me.MenuItem43 = New System.Windows.Forms.MenuItem
        Me.miPGM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem45 = New System.Windows.Forms.MenuItem
        Me.miPGM00002 = New System.Windows.Forms.MenuItem
        Me.miPGM00003 = New System.Windows.Forms.MenuItem
        Me.MenuItem48 = New System.Windows.Forms.MenuItem
        Me.miPGM00005 = New System.Windows.Forms.MenuItem
        Me.miPGM00004 = New System.Windows.Forms.MenuItem
        Me.miPGM00008 = New System.Windows.Forms.MenuItem
        Me.MenuItem52 = New System.Windows.Forms.MenuItem
        Me.miPGM00009 = New System.Windows.Forms.MenuItem
        Me.MenuItem54 = New System.Windows.Forms.MenuItem
        Me.miPGM00006 = New System.Windows.Forms.MenuItem
        Me.MenuItem57 = New System.Windows.Forms.MenuItem
        Me.miPGM00007 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.miSYM00104 = New System.Windows.Forms.MenuItem
        Me.miSYM00108 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.miCLM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.miCLR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem34 = New System.Windows.Forms.MenuItem
        Me.miBJR00001 = New System.Windows.Forms.MenuItem
        Me.miFTY00001 = New System.Windows.Forms.MenuItem
        Me.miFTY00004 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.miIAR00001 = New System.Windows.Forms.MenuItem
        Me.miIMR00017 = New System.Windows.Forms.MenuItem
        Me.miMSR00032 = New System.Windows.Forms.MenuItem
        Me.miIMR00013 = New System.Windows.Forms.MenuItem
        Me.miIMR00023 = New System.Windows.Forms.MenuItem
        Me.miIMR00027 = New System.Windows.Forms.MenuItem
        Me.miIMR00021 = New System.Windows.Forms.MenuItem
        Me.miIMR00022 = New System.Windows.Forms.MenuItem
        Me.MenuItem35 = New System.Windows.Forms.MenuItem
        Me.miINR00014 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.miMSR00002 = New System.Windows.Forms.MenuItem
        Me.miMSR00019 = New System.Windows.Forms.MenuItem
        Me.miMSR00020 = New System.Windows.Forms.MenuItem
        Me.miMSR00022 = New System.Windows.Forms.MenuItem
        Me.miMSR00031 = New System.Windows.Forms.MenuItem
        Me.miMSR00033 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.miMSR00001 = New System.Windows.Forms.MenuItem
        Me.miMSR00004 = New System.Windows.Forms.MenuItem
        Me.miMSR00012 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.miIMR00019 = New System.Windows.Forms.MenuItem
        Me.MenuItem36 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.miDYR00001 = New System.Windows.Forms.MenuItem
        Me.miDYR00002 = New System.Windows.Forms.MenuItem
        Me.miDYR00003 = New System.Windows.Forms.MenuItem
        Me.miDYR00004 = New System.Windows.Forms.MenuItem
        Me.miDYR00005 = New System.Windows.Forms.MenuItem
        Me.miDYR00006 = New System.Windows.Forms.MenuItem
        Me.miDYR00007 = New System.Windows.Forms.MenuItem
        Me.miDYR00008 = New System.Windows.Forms.MenuItem
        Me.miDYR00009 = New System.Windows.Forms.MenuItem
        Me.miDYR00010 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        Me.miCOR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.lbMenu = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'mmMenu
        '
        Me.mmMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFile, Me.miSystem, Me.miItem, Me.MenuItem3, Me.MenuItem7, Me.MenuItem18, Me.MenuItem9, Me.MenuItem29, Me.MenuItem11, Me.MenuItem13, Me.MenuItem19, Me.MenuItem41, Me.MenuItem1, Me.MenuItem34, Me.MenuItem22, Me.MenuItem10})
        '
        'miFile
        '
        Me.miFile.Index = 0
        Me.miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miReLogin, Me.MenuItem6, Me.miExit})
        Me.miFile.Text = "&File"
        '
        'miReLogin
        '
        Me.miReLogin.Index = 0
        Me.miReLogin.Text = "Re-Login"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 1
        Me.MenuItem6.Text = "-"
        '
        'miExit
        '
        Me.miExit.Index = 2
        Me.miExit.Text = "Exit"
        '
        'miSystem
        '
        Me.miSystem.Index = 1
        Me.miSystem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSYS00001, Me.miSYS00002, Me.miSYS00003, Me.miSYS00004, Me.MenuItem4, Me.miSYM00001, Me.miSYM00002, Me.miSYM00003, Me.miSYM00004, Me.miSYM00005, Me.miSYM00006, Me.miSYM00007, Me.miSYM00008, Me.miSYM00009, Me.miSYM00010, Me.miSYM00011, Me.miSYM00012, Me.miSYM00013, Me.miSYM00014, Me.miSYM00015, Me.miSYM00016, Me.miSYM00017, Me.miSYM00023, Me.miSYM00026, Me.miSYM00028, Me.miSYM00029, Me.MenuItem8, Me.miSYM00101})
        Me.miSystem.Text = "System"
        '
        'miSYS00001
        '
        Me.miSYS00001.Enabled = False
        Me.miSYS00001.Index = 0
        Me.miSYS00001.Text = "SYS00001 - User Group"
        '
        'miSYS00002
        '
        Me.miSYS00002.Enabled = False
        Me.miSYS00002.Index = 1
        Me.miSYS00002.Text = "SYS00002 - User Profile"
        '
        'miSYS00003
        '
        Me.miSYS00003.Enabled = False
        Me.miSYS00003.Index = 2
        Me.miSYS00003.Text = "SYS00003 - User Function"
        '
        'miSYS00004
        '
        Me.miSYS00004.Enabled = False
        Me.miSYS00004.Index = 3
        Me.miSYS00004.Text = "SYS00004 - User Authorization"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 4
        Me.MenuItem4.Text = "-"
        '
        'miSYM00001
        '
        Me.miSYM00001.Enabled = False
        Me.miSYM00001.Index = 5
        Me.miSYM00001.Text = "SYM00001 - Company"
        '
        'miSYM00002
        '
        Me.miSYM00002.Enabled = False
        Me.miSYM00002.Index = 6
        Me.miSYM00002.Text = "SYM00002 - System Document Control"
        '
        'miSYM00003
        '
        Me.miSYM00003.Enabled = False
        Me.miSYM00003.Index = 7
        Me.miSYM00003.Text = "SYM00003 - Color"
        '
        'miSYM00004
        '
        Me.miSYM00004.Enabled = False
        Me.miSYM00004.Index = 8
        Me.miSYM00004.Text = "SYM00004 - Product Line"
        '
        'miSYM00005
        '
        Me.miSYM00005.Enabled = False
        Me.miSYM00005.Index = 9
        Me.miSYM00005.Text = "SYM00005 - Category"
        '
        'miSYM00006
        '
        Me.miSYM00006.Enabled = False
        Me.miSYM00006.Index = 10
        Me.miSYM00006.Text = "SYM00006 - Category Relation"
        '
        'miSYM00007
        '
        Me.miSYM00007.Enabled = False
        Me.miSYM00007.Index = 11
        Me.miSYM00007.Text = "SYM00007 - Harmonized Code"
        '
        'miSYM00008
        '
        Me.miSYM00008.Enabled = False
        Me.miSYM00008.Index = 12
        Me.miSYM00008.Text = "SYM00008 - Setup"
        '
        'miSYM00009
        '
        Me.miSYM00009.Enabled = False
        Me.miSYM00009.Index = 13
        Me.miSYM00009.Text = "SYM00009 - Conversion Factor"
        '
        'miSYM00010
        '
        Me.miSYM00010.Enabled = False
        Me.miSYM00010.Index = 14
        Me.miSYM00010.Text = "SYM00010 - Sales Representative"
        '
        'miSYM00011
        '
        Me.miSYM00011.Enabled = False
        Me.miSYM00011.Index = 15
        Me.miSYM00011.Text = "SYM00011 - MOQ / MOA and Commission"
        '
        'miSYM00012
        '
        Me.miSYM00012.Enabled = False
        Me.miSYM00012.Index = 16
        Me.miSYM00012.Text = "SYM00012 - Agent"
        '
        'miSYM00013
        '
        Me.miSYM00013.Enabled = False
        Me.miSYM00013.Index = 17
        Me.miSYM00013.Text = "SYM00013 - Discount/Premium"
        '
        'miSYM00014
        '
        Me.miSYM00014.Enabled = False
        Me.miSYM00014.Index = 18
        Me.miSYM00014.Text = "SYM00014 - Sample Terms"
        '
        'miSYM00015
        '
        Me.miSYM00015.Enabled = False
        Me.miSYM00015.Index = 19
        Me.miSYM00015.Text = "SYM00015 - External Vendor Price Formula"
        '
        'miSYM00016
        '
        Me.miSYM00016.Enabled = False
        Me.miSYM00016.Index = 20
        Me.miSYM00016.Text = "SYM00016 - Internal Vendor Price Formula"
        '
        'miSYM00017
        '
        Me.miSYM00017.Enabled = False
        Me.miSYM00017.Index = 21
        Me.miSYM00017.Text = "SYM00017 - Formula Maintenance"
        '
        'miSYM00023
        '
        Me.miSYM00023.Enabled = False
        Me.miSYM00023.Index = 22
        Me.miSYM00023.Text = "SYM00023 - ABCD Cost Setup"
        '
        'miSYM00026
        '
        Me.miSYM00026.Enabled = False
        Me.miSYM00026.Index = 23
        Me.miSYM00026.Text = "SYM00026 - Currency Maintenance"
        '
        'miSYM00028
        '
        Me.miSYM00028.Enabled = False
        Me.miSYM00028.Index = 24
        Me.miSYM00028.Text = "SYM00028 - Sales Team Maintenance"
        '
        'miSYM00029
        '
        Me.miSYM00029.Enabled = False
        Me.miSYM00029.Index = 25
        Me.miSYM00029.Text = "SYM00029 - SAP Unit of Measure Mapping "
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 26
        Me.MenuItem8.Text = "-"
        '
        'miSYM00101
        '
        Me.miSYM00101.Enabled = False
        Me.miSYM00101.Index = 27
        Me.miSYM00101.Text = "SYM00101 - Shipping Charges Formula Setup"
        '
        'miItem
        '
        Me.miItem.Index = 2
        Me.miItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miIMM00001, Me.MenuItem14, Me.miIMXLS007, Me.miIMR00035, Me.MenuItem17, Me.miIMXLS001, Me.miIMM00002, Me.miIMM00013, Me.miIMR00004, Me.miIMR00005, Me.miIMR00034, Me.MenuItem16, Me.miIMXLS005, Me.miIMM00012, Me.miIMR00018, Me.MenuItem20, Me.miIMG00001, Me.miIMG00002})
        Me.miItem.Text = "Item"
        '
        'miIMM00001
        '
        Me.miIMM00001.Index = 0
        Me.miIMM00001.Text = "IMM00001 - Item Master Maintenance"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 1
        Me.MenuItem14.Text = "-"
        '
        'miIMXLS007
        '
        Me.miIMXLS007.Index = 2
        Me.miIMXLS007.Text = "IMXLS007 - Temp Item and Real Item Matching Excel File Upload"
        '
        'miIMR00035
        '
        Me.miIMR00035.Index = 3
        Me.miIMR00035.Text = "IMR00035  - Item Master Price Change Report"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 4
        Me.MenuItem17.Text = "-"
        '
        'miIMXLS001
        '
        Me.miIMXLS001.Index = 5
        Me.miIMXLS001.Text = "IMXLS001 - Item Excel File Upload (Interal && Joint Venture Item)"
        '
        'miIMM00002
        '
        Me.miIMM00002.Index = 6
        Me.miIMM00002.Text = "IMM00002 - Item Master Approval && Rejection (Internal && Joint Venture Item)"
        '
        'miIMM00013
        '
        Me.miIMM00013.Index = 7
        Me.miIMM00013.Text = "IMM00013 - Item Master Invalid Item Reactivation (Internal && Joint Venture Item)" & _
            ""
        '
        'miIMR00004
        '
        Me.miIMR00004.Index = 8
        Me.miIMR00004.Text = "IMR00004 - Item Validation Report (Internal && Joint Venture Item)"
        '
        'miIMR00005
        '
        Me.miIMR00005.Index = 9
        Me.miIMR00005.Text = "IMR00005 - Excel File Search Report (Internal && Joint Venture Item)"
        '
        'miIMR00034
        '
        Me.miIMR00034.Index = 10
        Me.miIMR00034.Text = "IMR00034 - Item Master Report Export (Internal && Joint Venture Item)"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 11
        Me.MenuItem16.Text = "-"
        '
        'miIMXLS005
        '
        Me.miIMXLS005.Index = 12
        Me.miIMXLS005.Text = "IMXLS005 - Item Excel File Upload (External Item)"
        '
        'miIMM00012
        '
        Me.miIMM00012.Index = 13
        Me.miIMM00012.Text = "IMM00012 - Item Master Approval && Rejection (External Item)"
        '
        'miIMR00018
        '
        Me.miIMR00018.Index = 14
        Me.miIMR00018.Text = "IMR00018 - Item Validation Report (External Item)"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 15
        Me.MenuItem20.Text = "-"
        '
        'miIMG00001
        '
        Me.miIMG00001.Index = 16
        Me.miIMG00001.Text = "IMGx00001 - Item Master Image Upload"
        '
        'miIMG00002
        '
        Me.miIMG00002.Index = 17
        Me.miIMG00002.Text = "IMGx00002 - Item Master Image Upload (External Item)"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 3
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miCUM00001, Me.miCUM00002, Me.miCUM00003})
        Me.MenuItem3.Text = "Customer"
        '
        'miCUM00001
        '
        Me.miCUM00001.Index = 0
        Me.miCUM00001.Text = "CUM00001 - Customer Master Maintenance"
        '
        'miCUM00002
        '
        Me.miCUM00002.Index = 1
        Me.miCUM00002.Text = "CUM00002 - Customer Item History (Old)"
        '
        'miCUM00003
        '
        Me.miCUM00003.Index = 2
        Me.miCUM00003.Text = "CUM00003 - Customer Item History (New)"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 4
        Me.MenuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miVNM00001, Me.MenuItem27, Me.miSYM00102, Me.miSYM00103, Me.MenuItem15, Me.miSYR00103})
        Me.MenuItem7.Text = "Vendor"
        '
        'miVNM00001
        '
        Me.miVNM00001.Index = 0
        Me.miVNM00001.Text = "VNM00001 - Vendor Master Maintenance"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 1
        Me.MenuItem27.Text = "-"
        '
        'miSYM00102
        '
        Me.miSYM00102.Enabled = False
        Me.miSYM00102.Index = 2
        Me.miSYM00102.Text = "SYM00102 - Trading Term Maintenance "
        '
        'miSYM00103
        '
        Me.miSYM00103.Enabled = False
        Me.miSYM00103.Index = 3
        Me.miSYM00103.Text = "SYM00103 - Vendor Trading Term Setup"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 4
        Me.MenuItem15.Text = "-"
        '
        'miSYR00103
        '
        Me.miSYR00103.Enabled = False
        Me.miSYR00103.Index = 5
        Me.miSYR00103.Text = "SYR00103 - Vendor Trading Terms List Report"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 5
        Me.MenuItem18.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miQUM00001, Me.MenuItem33, Me.miQUM00004, Me.MenuItem31, Me.miQUR00001, Me.MenuItem28, Me.miQUXLS001, Me.miQUR00003, Me.MenuItem30, Me.miIMXLS004, Me.miIMR00010})
        Me.MenuItem18.Text = "Quotation"
        '
        'miQUM00001
        '
        Me.miQUM00001.Index = 0
        Me.miQUM00001.Text = "QUM00001 - Quotation Maintenance"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 1
        Me.MenuItem33.Text = "QUAPP001 - Quotation Apps Approval / Reject"
        '
        'miQUM00004
        '
        Me.miQUM00004.Enabled = False
        Me.miQUM00004.Index = 2
        Me.miQUM00004.Text = "QUM00004 - PDA Quotation Approve / Reject"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 3
        Me.MenuItem31.Text = "-"
        '
        'miQUR00001
        '
        Me.miQUR00001.Index = 4
        Me.miQUR00001.Text = "QUR00001 - Print Quotation"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 5
        Me.MenuItem28.Text = "-"
        '
        'miQUXLS001
        '
        Me.miQUXLS001.Index = 6
        Me.miQUXLS001.Text = "QUXLS001 - Upload Quotation Excel to ERP"
        '
        'miQUR00003
        '
        Me.miQUR00003.Index = 7
        Me.miQUR00003.Text = "QUR00003 - Export Quotation to Excel"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 8
        Me.MenuItem30.Text = "-"
        '
        'miIMXLS004
        '
        Me.miIMXLS004.Enabled = False
        Me.miIMXLS004.Index = 9
        Me.miIMXLS004.Text = "IMXLSx004 - Customer Style Number"
        '
        'miIMR00010
        '
        Me.miIMR00010.Enabled = False
        Me.miIMR00010.Index = 10
        Me.miIMR00010.Text = "IMRx00010 - Item Validation Report (Customer Style Number)"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 6
        Me.MenuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSAM00004, Me.miSAM00001, Me.miSAM00002, Me.miSAM00003, Me.miSAM00005, Me.MenuItem26, Me.miSAR00005, Me.miSAR00006, Me.miSAR00007})
        Me.MenuItem9.Text = "Sample"
        '
        'miSAM00004
        '
        Me.miSAM00004.Index = 0
        Me.miSAM00004.Text = "SAM00004 - Sample Request Generation"
        '
        'miSAM00001
        '
        Me.miSAM00001.Index = 1
        Me.miSAM00001.Text = "SAM00001 - Sample Request Maintenance"
        '
        'miSAM00002
        '
        Me.miSAM00002.Index = 2
        Me.miSAM00002.Text = "SAM00002 - Sample Order Summary"
        '
        'miSAM00003
        '
        Me.miSAM00003.Index = 3
        Me.miSAM00003.Text = "SAM00003 - Sample Invoice Information"
        '
        'miSAM00005
        '
        Me.miSAM00005.Index = 4
        Me.miSAM00005.Text = "SAM00005 - Sample Invoice Generation"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 5
        Me.MenuItem26.Text = "-"
        '
        'miSAR00005
        '
        Me.miSAR00005.Index = 6
        Me.miSAR00005.Text = "SAR00005 - Sample Invoice Report"
        '
        'miSAR00006
        '
        Me.miSAR00006.Index = 7
        Me.miSAR00006.Text = "SAR00006 - Sample Request Report "
        '
        'miSAR00007
        '
        Me.miSAR00007.Index = 8
        Me.miSAR00007.Text = "SAR00007 - Packing List Report"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 7
        Me.MenuItem29.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miTOM00002, Me.miTOM00001, Me.miTOM00003, Me.miTOM00004, Me.miTOM00005})
        Me.MenuItem29.Text = "Tentative"
        '
        'miTOM00002
        '
        Me.miTOM00002.Index = 0
        Me.miTOM00002.Text = "TOM00002 - Tentative Order Generation"
        '
        'miTOM00001
        '
        Me.miTOM00001.Index = 1
        Me.miTOM00001.Text = "TOM00001 - Tentative Order Maintenance"
        '
        'miTOM00003
        '
        Me.miTOM00003.Index = 2
        Me.miTOM00003.Text = "TOM00003 - Tenetaive Order Release/UnRelease"
        '
        'miTOM00004
        '
        Me.miTOM00004.Index = 3
        Me.miTOM00004.Text = "TOM00004 - Tentative Order History"
        '
        'miTOM00005
        '
        Me.miTOM00005.Index = 4
        Me.miTOM00005.Text = "TOM00005 - Export Tentative to Excel"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 8
        Me.MenuItem11.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSCM00001, Me.miSCM00004, Me.miSHR00002, Me.miSCM00003, Me.miSCM00006, Me.MenuItem21, Me.miSCR00001, Me.miSCR00003, Me.miIMR00009, Me.miIMR00024, Me.miIMR00025, Me.miIMR00026, Me.miIMR00029, Me.miIMR00030, Me.miIMR00031, Me.miIMR00032})
        Me.MenuItem11.Text = "Sales"
        '
        'miSCM00001
        '
        Me.miSCM00001.Index = 0
        Me.miSCM00001.Text = "SCM00001 - Sales Confirmation Maintenance"
        '
        'miSCM00004
        '
        Me.miSCM00004.Index = 1
        Me.miSCM00004.Text = "SCM00004 - Transport Shipmark Maintenance"
        '
        'miSHR00002
        '
        Me.miSHR00002.Index = 2
        Me.miSHR00002.Text = "SHR00002 - Release/Unrelease Sales Confirmation"
        '
        'miSCM00003
        '
        Me.miSCM00003.Index = 3
        Me.miSCM00003.Text = "SCM00003 - SC Factory Data Approval && Rejecction"
        '
        'miSCM00006
        '
        Me.miSCM00006.Index = 4
        Me.miSCM00006.Text = "SCM00006 - SC Approval && Rejection"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 5
        Me.MenuItem21.Text = "-"
        '
        'miSCR00001
        '
        Me.miSCR00001.Index = 6
        Me.miSCR00001.Text = "SCR00001 - Print Sales Confirmation Report"
        '
        'miSCR00003
        '
        Me.miSCR00003.Index = 7
        Me.miSCR00003.Text = "SCR00003 - Print Cancellation SC with BOM Item"
        '
        'miIMR00009
        '
        Me.miIMR00009.Index = 8
        Me.miIMR00009.Text = "IMR00009 - Print Product Label List"
        '
        'miIMR00024
        '
        Me.miIMR00024.Index = 9
        Me.miIMR00024.Text = "IMR00024 - Attachment Update History"
        '
        'miIMR00025
        '
        Me.miIMR00025.Index = 10
        Me.miIMR00025.Text = "IMR00025 - MOQ SC Records"
        '
        'miIMR00026
        '
        Me.miIMR00026.Index = 11
        Me.miIMR00026.Text = "IMR00026 - MOQ Outstanding Records"
        Me.miIMR00026.Visible = False
        '
        'miIMR00029
        '
        Me.miIMR00029.Index = 12
        Me.miIMR00029.Text = "IMR00029 - Factory Approve Data Comparison Report"
        '
        'miIMR00030
        '
        Me.miIMR00030.Index = 13
        Me.miIMR00030.Text = "IMR00030 - Factory Approve Data Batch Report"
        '
        'miIMR00031
        '
        Me.miIMR00031.Index = 14
        Me.miIMR00031.Text = "IMR00031 - Sales Confirmation List to Excel"
        '
        'miIMR00032
        '
        Me.miIMR00032.Index = 15
        Me.miIMR00032.Text = "IMR00032 - Late Shipment Report"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 9
        Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.imPOM00001, Me.miSHR00003, Me.miBOM00001, Me.MenuItem32, Me.miPOR00001, Me.miPOR00003, Me.miPOR00005, Me.miPOR00007, Me.miBOR00001, Me.MenuItem38, Me.miPOM00010})
        Me.MenuItem13.Text = "Purchase"
        '
        'imPOM00001
        '
        Me.imPOM00001.Index = 0
        Me.imPOM00001.Text = "POM00001 - Purchase Order Maintenance"
        '
        'miSHR00003
        '
        Me.miSHR00003.Index = 1
        Me.miSHR00003.Text = "SHR00003 - Release/Unrelease Purchase Order"
        '
        'miBOM00001
        '
        Me.miBOM00001.Index = 2
        Me.miBOM00001.Text = "BOM00001 - BOM Order Maintenance"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 3
        Me.MenuItem32.Text = "-"
        '
        'miPOR00001
        '
        Me.miPOR00001.Index = 4
        Me.miPOR00001.Text = "POR00001 - Purchase Order Report"
        '
        'miPOR00003
        '
        Me.miPOR00003.Index = 5
        Me.miPOR00003.Text = "POR00003 - BOM Purchase Order"
        '
        'miPOR00005
        '
        Me.miPOR00005.Index = 6
        Me.miPOR00005.Text = "POR00005 - Print Production Note (Job Order)"
        '
        'miPOR00007
        '
        Me.miPOR00007.Index = 7
        Me.miPOR00007.Text = "POR00007 - BOM PO Report (Export to Excel)"
        '
        'miBOR00001
        '
        Me.miBOR00001.Index = 8
        Me.miBOR00001.Text = "BOR00001 - Vendor Purchase Report (BOM)"
        '
        'MenuItem38
        '
        Me.MenuItem38.Index = 9
        Me.MenuItem38.Text = "-"
        '
        'miPOM00010
        '
        Me.miPOM00010.Enabled = False
        Me.miPOM00010.Index = 10
        Me.miPOM00010.Text = "POM00010 - Purchase Order Approval Maintenance"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 10
        Me.MenuItem19.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSHM00010, Me.miSHR00010, Me.MenuItem42, Me.miINR00001, Me.miPKR00001})
        Me.MenuItem19.Text = "Shipping"
        '
        'miSHM00010
        '
        Me.miSHM00010.Enabled = False
        Me.miSHM00010.Index = 0
        Me.miSHM00010.Text = "SHM00010 - Shipping Charges Maintenance"
        '
        'miSHR00010
        '
        Me.miSHR00010.Enabled = False
        Me.miSHR00010.Index = 1
        Me.miSHR00010.Text = "SHR00010 - Shipping Charges Report"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 2
        Me.MenuItem42.Text = "-"
        '
        'miINR00001
        '
        Me.miINR00001.Enabled = False
        Me.miINR00001.Index = 3
        Me.miINR00001.Text = "INR00001 - Print Invoice"
        '
        'miPKR00001
        '
        Me.miPKR00001.Enabled = False
        Me.miPKR00001.Index = 4
        Me.miPKR00001.Text = "PKR00001 - Print Packing List"
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 11
        Me.MenuItem41.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSYM00031, Me.MenuItem43, Me.miPGM00001, Me.MenuItem45, Me.miPGM00002, Me.miPGM00003, Me.MenuItem48, Me.miPGM00005, Me.miPGM00004, Me.miPGM00008, Me.MenuItem52, Me.miPGM00009, Me.MenuItem54, Me.miPGM00006, Me.MenuItem57, Me.miPGM00007})
        Me.MenuItem41.Text = "Packaging"
        '
        'miSYM00031
        '
        Me.miSYM00031.Index = 0
        Me.miSYM00031.Text = "SYM00031 - Packaging Component Maintenance"
        '
        'MenuItem43
        '
        Me.MenuItem43.Index = 1
        Me.MenuItem43.Text = "-"
        '
        'miPGM00001
        '
        Me.miPGM00001.Index = 2
        Me.miPGM00001.Text = "PGM00001 - Packaging Item Master Maintenance"
        '
        'MenuItem45
        '
        Me.MenuItem45.Index = 3
        Me.MenuItem45.Text = "-"
        '
        'miPGM00002
        '
        Me.miPGM00002.Index = 4
        Me.miPGM00002.Text = "PGM00002 - Packaging Request Maintenance"
        '
        'miPGM00003
        '
        Me.miPGM00003.Index = 5
        Me.miPGM00003.Text = "PGM00003 - Release/Unrelease Packaging Request"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 6
        Me.MenuItem48.Text = "-"
        '
        'miPGM00005
        '
        Me.miPGM00005.Index = 7
        Me.miPGM00005.Text = "PGM00005 - Packaging Order Generation and Update"
        '
        'miPGM00004
        '
        Me.miPGM00004.Index = 8
        Me.miPGM00004.Text = "PGM00004 - Packaging Order Maintenance"
        '
        'miPGM00008
        '
        Me.miPGM00008.Index = 9
        Me.miPGM00008.Text = "PGM00008 - Release/Unrelease Packaging Order"
        '
        'MenuItem52
        '
        Me.MenuItem52.Index = 10
        Me.MenuItem52.Text = "-"
        '
        'miPGM00009
        '
        Me.miPGM00009.Index = 11
        Me.miPGM00009.Text = "PGM00009 - Packaging Order Creation (Label/Hangtag)"
        '
        'MenuItem54
        '
        Me.MenuItem54.Index = 12
        Me.MenuItem54.Text = "-"
        '
        'miPGM00006
        '
        Me.miPGM00006.Index = 13
        Me.miPGM00006.Text = "PGM00006 - Packaging Order Approval"
        '
        'MenuItem57
        '
        Me.MenuItem57.Index = 14
        Me.MenuItem57.Text = "-"
        '
        'miPGM00007
        '
        Me.miPGM00007.Index = 15
        Me.miPGM00007.Text = "PGM00007 - Print Packaging Order"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 12
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSYM00104, Me.miSYM00108, Me.MenuItem2, Me.miCLM00001, Me.MenuItem12, Me.miCLR00001})
        Me.MenuItem1.Text = "Claims"
        '
        'miSYM00104
        '
        Me.miSYM00104.Enabled = False
        Me.miSYM00104.Index = 0
        Me.miSYM00104.Text = "SYM00104 - Claims Category Maintenance"
        '
        'miSYM00108
        '
        Me.miSYM00108.Enabled = False
        Me.miSYM00108.Index = 1
        Me.miSYM00108.Text = "SYM00108 - Claims Currency Maintenance"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.Text = "-"
        '
        'miCLM00001
        '
        Me.miCLM00001.Enabled = False
        Me.miCLM00001.Index = 3
        Me.miCLM00001.Text = "CLM00001 - Claims Transaction Maintenance"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 4
        Me.MenuItem12.Text = "-"
        '
        'miCLR00001
        '
        Me.miCLR00001.Enabled = False
        Me.miCLR00001.Index = 5
        Me.miCLR00001.Text = "CLR00001 - Print Claims Report"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 13
        Me.MenuItem34.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miBJR00001, Me.miFTY00001, Me.miFTY00004})
        Me.MenuItem34.Text = "PDO"
        '
        'miBJR00001
        '
        Me.miBJR00001.Enabled = False
        Me.miBJR00001.Index = 0
        Me.miBJR00001.Text = "BJR00001 - Batch Job Generation"
        '
        'miFTY00001
        '
        Me.miFTY00001.Enabled = False
        Me.miFTY00001.Index = 1
        Me.miFTY00001.Text = "FTY00001 - PDO System"
        '
        'miFTY00004
        '
        Me.miFTY00004.Enabled = False
        Me.miFTY00004.Index = 2
        Me.miFTY00004.Text = "FTY00004 - PDO Document History"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 14
        Me.MenuItem22.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem23, Me.MenuItem25, Me.MenuItem5, Me.MenuItem37, Me.MenuItem39, Me.MenuItem36, Me.MenuItem24, Me.MenuItem40, Me.miCOR00001})
        Me.MenuItem22.Text = "Report"
        '
        'MenuItem23
        '
        Me.MenuItem23.Enabled = False
        Me.MenuItem23.Index = 0
        Me.MenuItem23.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miIAR00001, Me.miIMR00017, Me.miMSR00032, Me.miIMR00013, Me.miIMR00023, Me.miIMR00027, Me.miIMR00021, Me.miIMR00022, Me.MenuItem35, Me.miINR00014})
        Me.MenuItem23.Text = "Item Information Report"
        '
        'miIAR00001
        '
        Me.miIAR00001.Enabled = False
        Me.miIAR00001.Index = 0
        Me.miIAR00001.Text = "IAR00001 - Impact Analysis Report"
        '
        'miIMR00017
        '
        Me.miIMR00017.Enabled = False
        Me.miIMR00017.Index = 1
        Me.miIMR00017.Text = "IMR00017 - Item Pricing Report (Export to Excel)"
        '
        'miMSR00032
        '
        Me.miMSR00032.Enabled = False
        Me.miMSR00032.Index = 2
        Me.miMSR00032.Text = "MSR00032 - Document List by Item"
        '
        'miIMR00013
        '
        Me.miIMR00013.Enabled = False
        Me.miIMR00013.Index = 3
        Me.miIMR00013.Text = "IMR00013 - Item Image Analyst Report"
        '
        'miIMR00023
        '
        Me.miIMR00023.Enabled = False
        Me.miIMR00023.Index = 4
        Me.miIMR00023.Text = "IMR00023 - Export Item Image to Excel"
        '
        'miIMR00027
        '
        Me.miIMR00027.Enabled = False
        Me.miIMR00027.Index = 5
        Me.miIMR00027.Text = "IMR00027 - Export Item Image to Excel (with Barcode)"
        '
        'miIMR00021
        '
        Me.miIMR00021.Enabled = False
        Me.miIMR00021.Index = 6
        Me.miIMR00021.Text = "IMR00021 - Assorted Item List"
        '
        'miIMR00022
        '
        Me.miIMR00022.Enabled = False
        Me.miIMR00022.Index = 7
        Me.miIMR00022.Text = "IMR00022 - Customer Alias Item List"
        '
        'MenuItem35
        '
        Me.MenuItem35.Index = 8
        Me.MenuItem35.Text = "-"
        '
        'miINR00014
        '
        Me.miINR00014.Enabled = False
        Me.miINR00014.Index = 9
        Me.miINR00014.Text = "INR00014 - CBM Report"
        '
        'MenuItem25
        '
        Me.MenuItem25.Enabled = False
        Me.MenuItem25.Index = 1
        Me.MenuItem25.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miMSR00002, Me.miMSR00019, Me.miMSR00020, Me.miMSR00022, Me.miMSR00031, Me.miMSR00033})
        Me.MenuItem25.Text = "Document Index / Record Listing"
        '
        'miMSR00002
        '
        Me.miMSR00002.Enabled = False
        Me.miMSR00002.Index = 0
        Me.miMSR00002.Text = "MSR00002 - Quotation Index"
        '
        'miMSR00019
        '
        Me.miMSR00019.Enabled = False
        Me.miMSR00019.Index = 1
        Me.miMSR00019.Text = "MSR00019 - Sales Confirmation Index"
        '
        'miMSR00020
        '
        Me.miMSR00020.Enabled = False
        Me.miMSR00020.Index = 2
        Me.miMSR00020.Text = "MSR00020 - Purchase Order Index"
        '
        'miMSR00022
        '
        Me.miMSR00022.Enabled = False
        Me.miMSR00022.Index = 3
        Me.miMSR00022.Text = "MSR00022 - BOM PO Index"
        '
        'miMSR00031
        '
        Me.miMSR00031.Enabled = False
        Me.miMSR00031.Index = 4
        Me.miMSR00031.Text = "MSR00031 - Invoice Index"
        '
        'miMSR00033
        '
        Me.miMSR00033.Enabled = False
        Me.miMSR00033.Index = 5
        Me.miMSR00033.Text = "MSR00033 - Sample Invoice Index"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.Text = "-"
        '
        'MenuItem37
        '
        Me.MenuItem37.Enabled = False
        Me.MenuItem37.Index = 3
        Me.MenuItem37.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miMSR00001, Me.miMSR00004, Me.miMSR00012})
        Me.MenuItem37.Text = "Outstanding Reports"
        '
        'miMSR00001
        '
        Me.miMSR00001.Enabled = False
        Me.miMSR00001.Index = 0
        Me.miMSR00001.Text = "MSR00001 - Outstanding Report By Sales Confirmation"
        '
        'miMSR00004
        '
        Me.miMSR00004.Enabled = False
        Me.miMSR00004.Index = 1
        Me.miMSR00004.Text = "MSR00004 - Outstanding Report By Vendor"
        '
        'miMSR00012
        '
        Me.miMSR00012.Enabled = False
        Me.miMSR00012.Index = 2
        Me.miMSR00012.Text = "MSR00012 - Outstanding Report By Customer"
        '
        'MenuItem39
        '
        Me.MenuItem39.Enabled = False
        Me.MenuItem39.Index = 4
        Me.MenuItem39.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miIMR00019})
        Me.MenuItem39.Text = "Sales Analysis Reports"
        '
        'miIMR00019
        '
        Me.miIMR00019.Enabled = False
        Me.miIMR00019.Index = 0
        Me.miIMR00019.Text = "IMR00019 - External Item Image List (Export to Excel)"
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 5
        Me.MenuItem36.Text = "-"
        '
        'MenuItem24
        '
        Me.MenuItem24.Enabled = False
        Me.MenuItem24.Index = 6
        Me.MenuItem24.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miDYR00001, Me.miDYR00002, Me.miDYR00003, Me.miDYR00004, Me.miDYR00005, Me.miDYR00006, Me.miDYR00007, Me.miDYR00008, Me.miDYR00009, Me.miDYR00010})
        Me.MenuItem24.Text = "Data Extraction"
        '
        'miDYR00001
        '
        Me.miDYR00001.Enabled = False
        Me.miDYR00001.Index = 0
        Me.miDYR00001.Text = "DYR00001 - vw_CIH_Repoort"
        '
        'miDYR00002
        '
        Me.miDYR00002.Enabled = False
        Me.miDYR00002.Index = 1
        Me.miDYR00002.Text = "DYR00002 - vw_CusMaster_EC2"
        '
        'miDYR00003
        '
        Me.miDYR00003.Enabled = False
        Me.miDYR00003.Index = 2
        Me.miDYR00003.Text = "DYR00003 - vw_ItemMaster"
        '
        'miDYR00004
        '
        Me.miDYR00004.Enabled = False
        Me.miDYR00004.Index = 3
        Me.miDYR00004.Text = "DYR00004 - vw_ItemMaster_Hist"
        '
        'miDYR00005
        '
        Me.miDYR00005.Enabled = False
        Me.miDYR00005.Index = 4
        Me.miDYR00005.Text = "DYR00005 - vw_SYSETINF"
        '
        'miDYR00006
        '
        Me.miDYR00006.Enabled = False
        Me.miDYR00006.Index = 5
        Me.miDYR00006.Text = "DYR00006 - vw_Quotation"
        '
        'miDYR00007
        '
        Me.miDYR00007.Enabled = False
        Me.miDYR00007.Index = 6
        Me.miDYR00007.Text = "DYR00007 - vw_SampleInvoice"
        '
        'miDYR00008
        '
        Me.miDYR00008.Enabled = False
        Me.miDYR00008.Index = 7
        Me.miDYR00008.Text = "DYR00008 - vw_SampleRequest"
        '
        'miDYR00009
        '
        Me.miDYR00009.Enabled = False
        Me.miDYR00009.Index = 8
        Me.miDYR00009.Text = "DYR00009 - vw_SalesConfirmation_EC"
        '
        'miDYR00010
        '
        Me.miDYR00010.Enabled = False
        Me.miDYR00010.Index = 9
        Me.miDYR00010.Text = "DYR00010 - vw_ShippingInfo"
        '
        'MenuItem40
        '
        Me.MenuItem40.Index = 7
        Me.MenuItem40.Text = "-"
        '
        'miCOR00001
        '
        Me.miCOR00001.Enabled = False
        Me.miCOR00001.Index = 8
        Me.miCOR00001.Text = "COR00001 - Audit Trail Report"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 15
        Me.MenuItem10.MdiList = True
        Me.MenuItem10.Text = "Windows"
        '
        'lbMenu
        '
        Me.lbMenu.Location = New System.Drawing.Point(8, 333)
        Me.lbMenu.Name = "lbMenu"
        Me.lbMenu.Size = New System.Drawing.Size(96, 4)
        Me.lbMenu.TabIndex = 4
        Me.lbMenu.Visible = False
        '
        'ERP00000
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(864, 309)
        Me.Controls.Add(Me.lbMenu)
        Me.DoubleBuffered = True
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Menu = Me.mmMenu
        Me.Name = "ERP00000"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ERP00000"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim timeout As Timer
    Const timeout_tick As Integer = 1000
    Const timeout_max As Integer = 3600000

    Private Sub miExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miExit.Click
        Me.Close()
    End Sub

    Private Sub ERP00000_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbMenu.Visible = False

        'SkipExitMsg = False

        '1. Menu Rights Check
        Dim i, j, k As Integer
        'Dim rs_SYUSRGRP As New DataSet
        Dim m1 As New MenuItem
        Dim m2 As New MenuItem
        Dim m3 As New MenuItem

        Dim s1, s2, s3 As String

        gspStr = "sp_select_SYUSRGRP_1 '', 'UCG','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRGRP_right, rtnStr)

        If rtnLong = RC_SUCCESS Then

            For i = 0 To rs_SYUSRGRP_right.Tables("RESULT").Rows.Count() - 1
                lbMenu.Items.Add(rs_SYUSRGRP_right.Tables("RESULT").Rows(i).Item("yug_usrfun"))
            Next

            ' i = 1 escape for the File Column
            For i = 1 To Me.mmMenu.MenuItems.Count - 1
                m1 = Me.mmMenu.MenuItems(i)
                If m1.IsParent() Then
                    m1.Enabled = True
                Else
                    s1 = Mid(m1.Text, 1, 8)
                    If lbMenu.Items.IndexOf(s1) >= 0 Then
                        m1.Enabled = True
                    Else
                        m1.Enabled = False
                    End If
                End If

                For j = 0 To m1.MenuItems.Count - 1
                    m2 = m1.MenuItems(j)
                    If m2.IsParent() Then
                        m2.Enabled = True
                    Else
                        s2 = Mid(m2.Text, 1, 8)
                        If lbMenu.Items.IndexOf(s2) >= 0 Then
                            m2.Enabled = True
                        Else
                            m2.Enabled = False
                            'FOR TESTING PURPORSES
                            'm2.Enabled = True
                        End If
                    End If
                    For k = 0 To m2.MenuItems.Count - 1
                        m3 = m2.MenuItems(k)
                        If m3.IsParent() Then
                            m3.Enabled = True
                        Else
                            s3 = Mid(m3.Text, 1, 8)
                            If lbMenu.Items.IndexOf(s3) >= 0 Then
                                m3.Enabled = True
                            Else
                                'm3.Enabled = False
                                m3.Enabled = False
                            End If
                        End If
                    Next
                Next
            Next


            timeout = New Timer()
            timeout.Interval = timeout_tick
            timeout.Interval = timeout_max
            timeout.Enabled = True
            AddHandler timeout.Tick, AddressOf timeout_Trigger
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

    Private Sub miReLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReLogin.Click
        'SkipExitMsg = True

        Dim reLogin As New ERP00001
        reLogin.Show()
        Me.Close()
        reLogin = Nothing
    End Sub
    Private Sub menu_log(ByVal menu As String)
        'gspStr = "sp_insert_menulog "
    End Sub

    Private Sub miSYS00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYS00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPOM00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPOM00010.Click
        showForm(sender, Me)
    End Sub

    Private Sub ERP00000_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Owner.Close()
    End Sub

    Private Sub miSHM00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSHM00010.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSHR00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSHR00010.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYS00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYS00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00007.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00010.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00013.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00014_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00014.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00015_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00015.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00017_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00017.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00101.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miINR00014_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miINR00014.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00006.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00007.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00008.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00009.Click
        showForm(sender, Me)
    End Sub

    Private Sub miDYR00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDYR00010.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCLM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCLM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00102.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00103.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00104_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00104.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYS00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYS00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYS00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYS00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCLM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showForm(sender, Me)
    End Sub

    Private Sub miCLR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCLR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCLR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showForm(sender, Me)
    End Sub

    Private Sub miSYR00103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYR00103.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00105_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00106_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00107_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showForm(sender, Me)
    End Sub

    Private Sub miFQM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00006.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00008.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00009.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00011_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00011.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00012.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00016_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00016.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00023_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00023.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00026_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00026.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMXLS005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMXLS005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00018_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00018.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMM00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMM00012.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMXLS001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMXLS001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMM00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMM00013.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMXLS007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMXLS007.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIAR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIAR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00035_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00035.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00034_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00034.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00017_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00017.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00032_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00032.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMG00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMG00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMG00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMG00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSCM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSCM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSCR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSCR00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSCM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSCM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSHR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSHR00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSCM00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSCR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSCR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00009.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00025_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00025.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00026_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00026.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00029_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00029.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00030_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00030.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00031_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00031.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00032_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00032.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00024_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00024.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQUM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQUM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSAM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSAM00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSAM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSAM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSAM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSAM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSAM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSAM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSAR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSAR00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSAR00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSAR00006.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSAR00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSAR00007.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQUM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQUM00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub imPOM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imPOM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSHR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSHR00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miBOM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBOM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCUM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCUM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQUR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQUR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMXLS004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMXLS004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00010.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPOR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPOR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPOR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPOR00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPOR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPOR00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPOR00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPOR00007.Click
        showForm(sender, Me)
    End Sub

    Private Sub miBOR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBOR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCUM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCUM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miVNM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miVNM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00028_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00028.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQUR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQUR00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQUXLS001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQUXLS001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCUM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCUM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miTOM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTOM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miTOM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTOM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miTOM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTOM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miTOM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTOM00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSAM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSAM00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSCM00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSCM00006.Click
        showForm(sender, Me)
    End Sub

    Private Sub miTOM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTOM00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub MenuItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem33.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00029_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00029.Click
        showForm(sender, Me)
    End Sub

    Private Sub miBJR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBJR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miFTY00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFTY00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miFTY00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFTY00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00013.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00023_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00023.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00027_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00027.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00021_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00021.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00022_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00022.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00019_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00019.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00020_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00020.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00022_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00022.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00031_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00031.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00033_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00033.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00012.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00019_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00019.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCOR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCOR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00031_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00031.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00008.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00009.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00006.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00007.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00108_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00108.Click
        showForm(sender, Me)
    End Sub

    Private Sub miINR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miINR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPKR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPKR00001.Click
        showForm(sender, Me)
    End Sub
End Class
