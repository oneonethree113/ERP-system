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
    Friend WithEvents miSYM00033 As System.Windows.Forms.MenuItem
    Friend WithEvents lbMenu As System.Windows.Forms.ListBox
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents miSHM00007 As System.Windows.Forms.MenuItem
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
    Friend WithEvents miSYM00037 As System.Windows.Forms.MenuItem
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
    Friend WithEvents miIMX00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00018 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00012 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMX00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00013 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00035 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMX00007 As System.Windows.Forms.MenuItem
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
    Friend WithEvents miSCM00007 As System.Windows.Forms.MenuItem
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
    Friend WithEvents miPOM00002 As System.Windows.Forms.MenuItem
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
    Friend WithEvents miQUX00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miCUM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miSAM00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miSCM00006 As System.Windows.Forms.MenuItem
    Friend WithEvents miTOM00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miQUA00001 As System.Windows.Forms.MenuItem
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
    Friend WithEvents miSYM00038 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents miINR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miPKR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem44 As System.Windows.Forms.MenuItem
    Friend WithEvents miACR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00011 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00012 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem49 As System.Windows.Forms.MenuItem
    Friend WithEvents miCLR00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miCLR00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00015 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00035 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00030 As System.Windows.Forms.MenuItem
    Friend WithEvents miSHM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem46 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem47 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00009 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00027 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00036 As System.Windows.Forms.MenuItem
    Friend WithEvents miRIR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00036 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem51 As System.Windows.Forms.MenuItem
    Friend WithEvents miSHM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem50 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem53 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPO00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPO00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPO00003 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem55 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPR0002 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPR00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPR00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPR00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miMPR00006 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem56 As System.Windows.Forms.MenuItem
    Friend WithEvents miMIM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miMIM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00020 As System.Windows.Forms.MenuItem
    Friend WithEvents miPCM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem58 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem60 As System.Windows.Forms.MenuItem
    Friend WithEvents miSMR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miSMR00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miBSP00004 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem59 As System.Windows.Forms.MenuItem
    Friend WithEvents miINR00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miINR00010 As System.Windows.Forms.MenuItem
    Friend WithEvents miINR00011 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem61 As System.Windows.Forms.MenuItem
    Friend WithEvents miINR00012 As System.Windows.Forms.MenuItem
    Friend WithEvents miINR00013 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00007 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem62 As System.Windows.Forms.MenuItem
    Friend WithEvents miMSR00008 As System.Windows.Forms.MenuItem
    Friend WithEvents miSCR00002 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem63 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00002 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00003 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem65 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem64 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00005 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00009 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00039 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem66 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00006 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMM00004 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGM00013 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGR00001 As System.Windows.Forms.MenuItem
    Friend WithEvents miPGX00001 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem67 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00007 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00040 As System.Windows.Forms.MenuItem
    Friend WithEvents miIMR00036 As System.Windows.Forms.MenuItem
    Friend WithEvents miSYM00032 As System.Windows.Forms.MenuItem
    Friend WithEvents miQCM00010 As System.Windows.Forms.MenuItem
    Friend WithEvents miPOM00003 As System.Windows.Forms.MenuItem
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
        Me.miSYM00033 = New System.Windows.Forms.MenuItem
        Me.miItem = New System.Windows.Forms.MenuItem
        Me.miIMM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.miIMM00004 = New System.Windows.Forms.MenuItem
        Me.miIMX00007 = New System.Windows.Forms.MenuItem
        Me.miIMR00035 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.miIMX00001 = New System.Windows.Forms.MenuItem
        Me.miIMM00002 = New System.Windows.Forms.MenuItem
        Me.miIMM00013 = New System.Windows.Forms.MenuItem
        Me.miIMR00004 = New System.Windows.Forms.MenuItem
        Me.miIMR00005 = New System.Windows.Forms.MenuItem
        Me.miIMR00034 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.miIMX00005 = New System.Windows.Forms.MenuItem
        Me.miIMM00012 = New System.Windows.Forms.MenuItem
        Me.miIMR00018 = New System.Windows.Forms.MenuItem
        Me.miIMM00015 = New System.Windows.Forms.MenuItem
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
        Me.miQUA00001 = New System.Windows.Forms.MenuItem
        Me.miQUM00004 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.miQUR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.miQUX00001 = New System.Windows.Forms.MenuItem
        Me.miQUR00003 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.miIMXLS004 = New System.Windows.Forms.MenuItem
        Me.miIMR00010 = New System.Windows.Forms.MenuItem
        Me.miRIR00001 = New System.Windows.Forms.MenuItem
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
        Me.miSCM00007 = New System.Windows.Forms.MenuItem
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
        Me.miIMR00036 = New System.Windows.Forms.MenuItem
        Me.miIMR00032 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.imPOM00001 = New System.Windows.Forms.MenuItem
        Me.miPOM00002 = New System.Windows.Forms.MenuItem
        Me.miBOM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.miPOR00001 = New System.Windows.Forms.MenuItem
        Me.miPOR00003 = New System.Windows.Forms.MenuItem
        Me.miPOR00005 = New System.Windows.Forms.MenuItem
        Me.miPOR00007 = New System.Windows.Forms.MenuItem
        Me.miBOR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem38 = New System.Windows.Forms.MenuItem
        Me.miPOM00003 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.miSHM00001 = New System.Windows.Forms.MenuItem
        Me.miSYM00030 = New System.Windows.Forms.MenuItem
        Me.MenuItem51 = New System.Windows.Forms.MenuItem
        Me.miSHM00002 = New System.Windows.Forms.MenuItem
        Me.MenuItem46 = New System.Windows.Forms.MenuItem
        Me.miSYM00036 = New System.Windows.Forms.MenuItem
        Me.miSHM00007 = New System.Windows.Forms.MenuItem
        Me.MenuItem42 = New System.Windows.Forms.MenuItem
        Me.miINR00001 = New System.Windows.Forms.MenuItem
        Me.miPKR00001 = New System.Windows.Forms.MenuItem
        Me.miSHR00010 = New System.Windows.Forms.MenuItem
        Me.MenuItem47 = New System.Windows.Forms.MenuItem
        Me.miMSR00009 = New System.Windows.Forms.MenuItem
        Me.miMSR00027 = New System.Windows.Forms.MenuItem
        Me.miMSR00036 = New System.Windows.Forms.MenuItem
        Me.MenuItem41 = New System.Windows.Forms.MenuItem
        Me.miSYM00031 = New System.Windows.Forms.MenuItem
        Me.MenuItem43 = New System.Windows.Forms.MenuItem
        Me.miPGM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem45 = New System.Windows.Forms.MenuItem
        Me.miPGM00002 = New System.Windows.Forms.MenuItem
        Me.miPGM00003 = New System.Windows.Forms.MenuItem
        Me.miPGX00001 = New System.Windows.Forms.MenuItem
        Me.miPGR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem48 = New System.Windows.Forms.MenuItem
        Me.miPGM00005 = New System.Windows.Forms.MenuItem
        Me.miPGM00004 = New System.Windows.Forms.MenuItem
        Me.miPGM00008 = New System.Windows.Forms.MenuItem
        Me.MenuItem52 = New System.Windows.Forms.MenuItem
        Me.miPGM00009 = New System.Windows.Forms.MenuItem
        Me.MenuItem54 = New System.Windows.Forms.MenuItem
        Me.miPGM00006 = New System.Windows.Forms.MenuItem
        Me.miPGM00011 = New System.Windows.Forms.MenuItem
        Me.miPGM00012 = New System.Windows.Forms.MenuItem
        Me.miPGM00013 = New System.Windows.Forms.MenuItem
        Me.MenuItem57 = New System.Windows.Forms.MenuItem
        Me.miPGM00007 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.miSYM00037 = New System.Windows.Forms.MenuItem
        Me.miSYM00038 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.miCLM00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem49 = New System.Windows.Forms.MenuItem
        Me.miCLR00004 = New System.Windows.Forms.MenuItem
        Me.miCLR00005 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.miCLR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem44 = New System.Windows.Forms.MenuItem
        Me.miPCM00001 = New System.Windows.Forms.MenuItem
        Me.miSYM00032 = New System.Windows.Forms.MenuItem
        Me.MenuItem58 = New System.Windows.Forms.MenuItem
        Me.miACR00001 = New System.Windows.Forms.MenuItem
        Me.MenuItem60 = New System.Windows.Forms.MenuItem
        Me.miSMR00001 = New System.Windows.Forms.MenuItem
        Me.miSMR00002 = New System.Windows.Forms.MenuItem
        Me.MenuItem34 = New System.Windows.Forms.MenuItem
        Me.miBJR00001 = New System.Windows.Forms.MenuItem
        Me.miFTY00001 = New System.Windows.Forms.MenuItem
        Me.miFTY00004 = New System.Windows.Forms.MenuItem
        Me.MenuItem50 = New System.Windows.Forms.MenuItem
        Me.miMPM00001 = New System.Windows.Forms.MenuItem
        Me.miMPM00002 = New System.Windows.Forms.MenuItem
        Me.miMPM00003 = New System.Windows.Forms.MenuItem
        Me.MenuItem53 = New System.Windows.Forms.MenuItem
        Me.miMPO00001 = New System.Windows.Forms.MenuItem
        Me.miMPO00002 = New System.Windows.Forms.MenuItem
        Me.miMPO00003 = New System.Windows.Forms.MenuItem
        Me.MenuItem55 = New System.Windows.Forms.MenuItem
        Me.miMPR00001 = New System.Windows.Forms.MenuItem
        Me.miMPR0002 = New System.Windows.Forms.MenuItem
        Me.miMPR00003 = New System.Windows.Forms.MenuItem
        Me.miMPR00004 = New System.Windows.Forms.MenuItem
        Me.miMPR00005 = New System.Windows.Forms.MenuItem
        Me.miMPR00006 = New System.Windows.Forms.MenuItem
        Me.MenuItem56 = New System.Windows.Forms.MenuItem
        Me.miMIM00001 = New System.Windows.Forms.MenuItem
        Me.miMIM00002 = New System.Windows.Forms.MenuItem
        Me.miSYM00020 = New System.Windows.Forms.MenuItem
        Me.MenuItem63 = New System.Windows.Forms.MenuItem
        Me.miSYM00039 = New System.Windows.Forms.MenuItem
        Me.miSYM00040 = New System.Windows.Forms.MenuItem
        Me.MenuItem66 = New System.Windows.Forms.MenuItem
        Me.miQCM00001 = New System.Windows.Forms.MenuItem
        Me.miQCM00002 = New System.Windows.Forms.MenuItem
        Me.miQCM00003 = New System.Windows.Forms.MenuItem
        Me.MenuItem65 = New System.Windows.Forms.MenuItem
        Me.miQCM00004 = New System.Windows.Forms.MenuItem
        Me.miQCM00009 = New System.Windows.Forms.MenuItem
        Me.MenuItem64 = New System.Windows.Forms.MenuItem
        Me.miQCM00005 = New System.Windows.Forms.MenuItem
        Me.miQCM00006 = New System.Windows.Forms.MenuItem
        Me.MenuItem67 = New System.Windows.Forms.MenuItem
        Me.miQCM00007 = New System.Windows.Forms.MenuItem
        Me.miQCM00010 = New System.Windows.Forms.MenuItem
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
        Me.miMSR00005 = New System.Windows.Forms.MenuItem
        Me.miMSR00035 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.miIMR00019 = New System.Windows.Forms.MenuItem
        Me.miINR00011 = New System.Windows.Forms.MenuItem
        Me.miSCR00002 = New System.Windows.Forms.MenuItem
        Me.miMSR00007 = New System.Windows.Forms.MenuItem
        Me.miBSP00004 = New System.Windows.Forms.MenuItem
        Me.MenuItem59 = New System.Windows.Forms.MenuItem
        Me.miINR00004 = New System.Windows.Forms.MenuItem
        Me.miINR00010 = New System.Windows.Forms.MenuItem
        Me.MenuItem61 = New System.Windows.Forms.MenuItem
        Me.miINR00013 = New System.Windows.Forms.MenuItem
        Me.miINR00012 = New System.Windows.Forms.MenuItem
        Me.MenuItem62 = New System.Windows.Forms.MenuItem
        Me.miMSR00008 = New System.Windows.Forms.MenuItem
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
        Me.mmMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFile, Me.miSystem, Me.miItem, Me.MenuItem3, Me.MenuItem7, Me.MenuItem18, Me.MenuItem9, Me.MenuItem29, Me.MenuItem11, Me.MenuItem13, Me.MenuItem19, Me.MenuItem41, Me.MenuItem1, Me.MenuItem44, Me.MenuItem34, Me.MenuItem50, Me.MenuItem63, Me.MenuItem22, Me.MenuItem10})
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
        Me.miSystem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSYS00001, Me.miSYS00002, Me.miSYS00003, Me.miSYS00004, Me.MenuItem4, Me.miSYM00001, Me.miSYM00002, Me.miSYM00003, Me.miSYM00004, Me.miSYM00005, Me.miSYM00006, Me.miSYM00007, Me.miSYM00008, Me.miSYM00009, Me.miSYM00010, Me.miSYM00011, Me.miSYM00012, Me.miSYM00013, Me.miSYM00014, Me.miSYM00015, Me.miSYM00016, Me.miSYM00017, Me.miSYM00023, Me.miSYM00026, Me.miSYM00028, Me.miSYM00029, Me.MenuItem8, Me.miSYM00033})
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
        'miSYM00033
        '
        Me.miSYM00033.Enabled = False
        Me.miSYM00033.Index = 27
        Me.miSYM00033.Text = "SYM00033 - Shipping Charges Formula Setup"
        '
        'miItem
        '
        Me.miItem.Index = 2
        Me.miItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miIMM00001, Me.MenuItem14, Me.miIMM00004, Me.miIMX00007, Me.miIMR00035, Me.MenuItem17, Me.miIMX00001, Me.miIMM00002, Me.miIMM00013, Me.miIMR00004, Me.miIMR00005, Me.miIMR00034, Me.MenuItem16, Me.miIMX00005, Me.miIMM00012, Me.miIMR00018, Me.miIMM00015, Me.MenuItem20, Me.miIMG00001, Me.miIMG00002})
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
        'miIMM00004
        '
        Me.miIMM00004.Index = 2
        Me.miIMM00004.Text = "IMM00004 - Hold / Release Item Status"
        '
        'miIMX00007
        '
        Me.miIMX00007.Index = 3
        Me.miIMX00007.Text = "IMX00007 - Temp Item and Real Item Matching Excel File Upload"
        '
        'miIMR00035
        '
        Me.miIMR00035.Index = 4
        Me.miIMR00035.Text = "IMR00035  - Item Master Price Change Report"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 5
        Me.MenuItem17.Text = "-"
        '
        'miIMX00001
        '
        Me.miIMX00001.Index = 6
        Me.miIMX00001.Text = "IMX00001 - Item Excel File Upload (Interal && Joint Venture Item)"
        '
        'miIMM00002
        '
        Me.miIMM00002.Index = 7
        Me.miIMM00002.Text = "IMM00002 - Item Master Approval && Rejection (Internal && Joint Venture Item)"
        '
        'miIMM00013
        '
        Me.miIMM00013.Index = 8
        Me.miIMM00013.Text = "IMM00013 - Item Master Invalid Item Reactivation (Internal && Joint Venture Item)" & _
            ""
        '
        'miIMR00004
        '
        Me.miIMR00004.Index = 9
        Me.miIMR00004.Text = "IMR00004 - Item Validation Report (Internal && Joint Venture Item)"
        '
        'miIMR00005
        '
        Me.miIMR00005.Index = 10
        Me.miIMR00005.Text = "IMR00005 - Excel File Search Report (Internal && Joint Venture Item)"
        '
        'miIMR00034
        '
        Me.miIMR00034.Index = 11
        Me.miIMR00034.Text = "IMR00034 - Item Master Report Export (Internal && Joint Venture Item)"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 12
        Me.MenuItem16.Text = "-"
        '
        'miIMX00005
        '
        Me.miIMX00005.Index = 13
        Me.miIMX00005.Text = "IMX00005 - Item Excel File Upload (External Item)"
        '
        'miIMM00012
        '
        Me.miIMM00012.Index = 14
        Me.miIMM00012.Text = "IMM00012 - Item Master Approval && Rejection (External Item)"
        '
        'miIMR00018
        '
        Me.miIMR00018.Index = 15
        Me.miIMR00018.Text = "IMR00018 - Item Validation Report (External Item)"
        '
        'miIMM00015
        '
        Me.miIMM00015.Index = 16
        Me.miIMM00015.Text = "IMM00015 - Item Master Data Export (External Item)"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 17
        Me.MenuItem20.Text = "-"
        '
        'miIMG00001
        '
        Me.miIMG00001.Index = 18
        Me.miIMG00001.Text = "IMG00001 - Item Master Image Upload"
        '
        'miIMG00002
        '
        Me.miIMG00002.Index = 19
        Me.miIMG00002.Text = "IMG00002 - Item Master Image Upload (External Item)"
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
        Me.MenuItem18.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miQUM00001, Me.miQUA00001, Me.miQUM00004, Me.MenuItem31, Me.miQUR00001, Me.MenuItem28, Me.miQUX00001, Me.miQUR00003, Me.MenuItem30, Me.miIMXLS004, Me.miIMR00010, Me.miRIR00001})
        Me.MenuItem18.Text = "Quotation"
        '
        'miQUM00001
        '
        Me.miQUM00001.Index = 0
        Me.miQUM00001.Text = "QUM00001 - Quotation Maintenance"
        '
        'miQUA00001
        '
        Me.miQUA00001.Index = 1
        Me.miQUA00001.Text = "QUA00001 - Quotation Apps Approval / Reject"
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
        'miQUX00001
        '
        Me.miQUX00001.Index = 6
        Me.miQUX00001.Text = "QUX00001 - Upload Quotation Excel to ERP"
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
        'miRIR00001
        '
        Me.miRIR00001.Enabled = False
        Me.miRIR00001.Index = 11
        Me.miRIR00001.Text = "RIR00001 - ReQuote Item List"
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
        Me.miTOM00003.Text = "TOM00003 - Tentative Order Release/UnRelease"
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
        Me.MenuItem11.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSCM00001, Me.miSCM00004, Me.miSCM00007, Me.miSCM00003, Me.miSCM00006, Me.MenuItem21, Me.miSCR00001, Me.miSCR00003, Me.miIMR00009, Me.miIMR00024, Me.miIMR00025, Me.miIMR00026, Me.miIMR00029, Me.miIMR00030, Me.miIMR00031, Me.miIMR00036, Me.miIMR00032})
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
        'miSCM00007
        '
        Me.miSCM00007.Index = 2
        Me.miSCM00007.Text = "SCM00007 - Release/Unrelease Sales Confirmation"
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
        'miIMR00036
        '
        Me.miIMR00036.Index = 15
        Me.miIMR00036.Text = "IMR00036 - Sales Confirmation List to Excel (Check Data)"
        '
        'miIMR00032
        '
        Me.miIMR00032.Index = 16
        Me.miIMR00032.Text = "IMR00032 - Late Shipment Report"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 9
        Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.imPOM00001, Me.miPOM00002, Me.miBOM00001, Me.MenuItem32, Me.miPOR00001, Me.miPOR00003, Me.miPOR00005, Me.miPOR00007, Me.miBOR00001, Me.MenuItem38, Me.miPOM00003})
        Me.MenuItem13.Text = "Purchase"
        '
        'imPOM00001
        '
        Me.imPOM00001.Index = 0
        Me.imPOM00001.Text = "POM00001 - Purchase Order Maintenance"
        '
        'miPOM00002
        '
        Me.miPOM00002.Index = 1
        Me.miPOM00002.Text = "POM00002 - Release/Unrelease Purchase Order"
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
        'miPOM00003
        '
        Me.miPOM00003.Enabled = False
        Me.miPOM00003.Index = 10
        Me.miPOM00003.Text = "POM00003 - Purchase Order Approval Maintenance"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 10
        Me.MenuItem19.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSHM00001, Me.miSYM00030, Me.MenuItem51, Me.miSHM00002, Me.MenuItem46, Me.miSYM00036, Me.miSHM00007, Me.MenuItem42, Me.miINR00001, Me.miPKR00001, Me.miSHR00010, Me.MenuItem47, Me.miMSR00009, Me.miMSR00027, Me.miMSR00036})
        Me.MenuItem19.Text = "Shipping"
        '
        'miSHM00001
        '
        Me.miSHM00001.Enabled = False
        Me.miSHM00001.Index = 0
        Me.miSHM00001.Text = "SHM00001 - Shipping Maintenance"
        '
        'miSYM00030
        '
        Me.miSYM00030.Enabled = False
        Me.miSYM00030.Index = 1
        Me.miSYM00030.Text = "SYM00030 - Shipping Customer Self-defined Maintenance"
        '
        'MenuItem51
        '
        Me.MenuItem51.Index = 2
        Me.MenuItem51.Text = "-"
        '
        'miSHM00002
        '
        Me.miSHM00002.Enabled = False
        Me.miSHM00002.Index = 3
        Me.miSHM00002.Text = "SHM00002 - Credit / Debit Note Information "
        '
        'MenuItem46
        '
        Me.MenuItem46.Index = 4
        Me.MenuItem46.Text = "-"
        '
        'miSYM00036
        '
        Me.miSYM00036.Enabled = False
        Me.miSYM00036.Index = 5
        Me.miSYM00036.Text = "SYM00036 - Shipping Forwarder Maintenance"
        '
        'miSHM00007
        '
        Me.miSHM00007.Enabled = False
        Me.miSHM00007.Index = 6
        Me.miSHM00007.Text = "SHM00007 - Shipping Charges Maintenance"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 7
        Me.MenuItem42.Text = "-"
        '
        'miINR00001
        '
        Me.miINR00001.Enabled = False
        Me.miINR00001.Index = 8
        Me.miINR00001.Text = "INR00001 - Print Invoice"
        '
        'miPKR00001
        '
        Me.miPKR00001.Enabled = False
        Me.miPKR00001.Index = 9
        Me.miPKR00001.Text = "PKR00001 - Print Packing List"
        '
        'miSHR00010
        '
        Me.miSHR00010.Enabled = False
        Me.miSHR00010.Index = 10
        Me.miSHR00010.Text = "SHR00010 - Print Shipping Charges Report"
        '
        'MenuItem47
        '
        Me.MenuItem47.Index = 11
        Me.MenuItem47.Text = "-"
        '
        'miMSR00009
        '
        Me.miMSR00009.Enabled = False
        Me.miMSR00009.Index = 12
        Me.miMSR00009.Text = "MSR00009 - Print Invoice Summary Report"
        '
        'miMSR00027
        '
        Me.miMSR00027.Enabled = False
        Me.miMSR00027.Index = 13
        Me.miMSR00027.Text = "MSR00027 - Print Container Search Report"
        '
        'miMSR00036
        '
        Me.miMSR00036.Enabled = False
        Me.miMSR00036.Index = 14
        Me.miMSR00036.Text = "MSR00036 - Print Container Summary Report By Customer"
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 11
        Me.MenuItem41.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSYM00031, Me.MenuItem43, Me.miPGM00001, Me.MenuItem45, Me.miPGM00002, Me.miPGM00003, Me.miPGX00001, Me.miPGR00001, Me.MenuItem48, Me.miPGM00005, Me.miPGM00004, Me.miPGM00008, Me.MenuItem52, Me.miPGM00009, Me.MenuItem54, Me.miPGM00006, Me.miPGM00011, Me.miPGM00012, Me.miPGM00013, Me.MenuItem57, Me.miPGM00007})
        Me.MenuItem41.Text = "Packaging"
        '
        'miSYM00031
        '
        Me.miSYM00031.Enabled = False
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
        Me.miPGM00001.Enabled = False
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
        Me.miPGM00002.Enabled = False
        Me.miPGM00002.Index = 4
        Me.miPGM00002.Text = "PGM00002 - Packaging Request Maintenance"
        '
        'miPGM00003
        '
        Me.miPGM00003.Enabled = False
        Me.miPGM00003.Index = 5
        Me.miPGM00003.Text = "PGM00003 - Release/Unrelease Packaging Request"
        '
        'miPGX00001
        '
        Me.miPGX00001.Enabled = False
        Me.miPGX00001.Index = 6
        Me.miPGX00001.Text = "PGX00001 - Excel Upload for Packaging Request Generation"
        '
        'miPGR00001
        '
        Me.miPGR00001.Enabled = False
        Me.miPGR00001.Index = 7
        Me.miPGR00001.Text = "PGR00001 - Packaging Request Information Export"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 8
        Me.MenuItem48.Text = "-"
        '
        'miPGM00005
        '
        Me.miPGM00005.Enabled = False
        Me.miPGM00005.Index = 9
        Me.miPGM00005.Text = "PGM00005 - Packaging Order Generation and Update"
        '
        'miPGM00004
        '
        Me.miPGM00004.Enabled = False
        Me.miPGM00004.Index = 10
        Me.miPGM00004.Text = "PGM00004 - Packaging Order Maintenance"
        '
        'miPGM00008
        '
        Me.miPGM00008.Enabled = False
        Me.miPGM00008.Index = 11
        Me.miPGM00008.Text = "PGM00008 - Release/Unrelease Packaging Order"
        '
        'MenuItem52
        '
        Me.MenuItem52.Index = 12
        Me.MenuItem52.Text = "-"
        '
        'miPGM00009
        '
        Me.miPGM00009.Enabled = False
        Me.miPGM00009.Index = 13
        Me.miPGM00009.Text = "PGM00009 - Packaging Order Creation (Label/Hangtag)"
        '
        'MenuItem54
        '
        Me.MenuItem54.Index = 14
        Me.MenuItem54.Text = "-"
        '
        'miPGM00006
        '
        Me.miPGM00006.Enabled = False
        Me.miPGM00006.Index = 15
        Me.miPGM00006.Text = "PGM00006 - Packaging Order Approval"
        '
        'miPGM00011
        '
        Me.miPGM00011.Enabled = False
        Me.miPGM00011.Index = 16
        Me.miPGM00011.Text = "PGM00011 - Packaging Order Approval (Read Only)"
        '
        'miPGM00012
        '
        Me.miPGM00012.Enabled = False
        Me.miPGM00012.Index = 17
        Me.miPGM00012.Text = "PGM00012 - Packaging Analysis Report"
        '
        'miPGM00013
        '
        Me.miPGM00013.Enabled = False
        Me.miPGM00013.Index = 18
        Me.miPGM00013.Text = "PGM00013 - Packaging Order Cost Comparsion Report"
        '
        'MenuItem57
        '
        Me.MenuItem57.Index = 19
        Me.MenuItem57.Text = "-"
        '
        'miPGM00007
        '
        Me.miPGM00007.Enabled = False
        Me.miPGM00007.Index = 20
        Me.miPGM00007.Text = "PGM00007 - Print Packaging Order"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 12
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSYM00037, Me.miSYM00038, Me.MenuItem2, Me.miCLM00001, Me.MenuItem49, Me.miCLR00004, Me.miCLR00005, Me.MenuItem12, Me.miCLR00001})
        Me.MenuItem1.Text = "Claims"
        '
        'miSYM00037
        '
        Me.miSYM00037.Enabled = False
        Me.miSYM00037.Index = 0
        Me.miSYM00037.Text = "SYM00037 - Claims Category Maintenance"
        '
        'miSYM00038
        '
        Me.miSYM00038.Enabled = False
        Me.miSYM00038.Index = 1
        Me.miSYM00038.Text = "SYM00038 - Claims Currency Maintenance"
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
        'MenuItem49
        '
        Me.MenuItem49.Index = 4
        Me.MenuItem49.Text = "-"
        '
        'miCLR00004
        '
        Me.miCLR00004.Enabled = False
        Me.miCLR00004.Index = 5
        Me.miCLR00004.Text = "CLR00004 - Claims Analysis Report (Account Format)"
        '
        'miCLR00005
        '
        Me.miCLR00005.Enabled = False
        Me.miCLR00005.Index = 6
        Me.miCLR00005.Text = "CLR00005 - Claims Analysis Report (Summary List Format)"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 7
        Me.MenuItem12.Text = "-"
        '
        'miCLR00001
        '
        Me.miCLR00001.Enabled = False
        Me.miCLR00001.Index = 8
        Me.miCLR00001.Text = "CLR00001 - Print Claims Report"
        '
        'MenuItem44
        '
        Me.MenuItem44.Index = 13
        Me.MenuItem44.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miPCM00001, Me.miSYM00032, Me.MenuItem58, Me.miACR00001, Me.MenuItem60, Me.miSMR00001, Me.miSMR00002})
        Me.MenuItem44.Text = "Account"
        '
        'miPCM00001
        '
        Me.miPCM00001.Enabled = False
        Me.miPCM00001.Index = 0
        Me.miPCM00001.Text = "PCM00001 - Account Setup Master"
        '
        'miSYM00032
        '
        Me.miSYM00032.Enabled = False
        Me.miSYM00032.Index = 1
        Me.miSYM00032.Text = "SYM00032 - Currency Maintenance (Account)"
        '
        'MenuItem58
        '
        Me.MenuItem58.Index = 2
        Me.MenuItem58.Text = "-"
        '
        'miACR00001
        '
        Me.miACR00001.Enabled = False
        Me.miACR00001.Index = 3
        Me.miACR00001.Text = "ACR00001 - LAI FEI Analysis Report"
        '
        'MenuItem60
        '
        Me.MenuItem60.Index = 4
        Me.MenuItem60.Text = "-"
        '
        'miSMR00001
        '
        Me.miSMR00001.Enabled = False
        Me.miSMR00001.Index = 5
        Me.miSMR00001.Text = "SMR00001 - Shipment Matching Report"
        '
        'miSMR00002
        '
        Me.miSMR00002.Enabled = False
        Me.miSMR00002.Index = 6
        Me.miSMR00002.Text = "SMR00002 - Shipment Matching Report (Summary)"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 14
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
        'MenuItem50
        '
        Me.MenuItem50.Index = 15
        Me.MenuItem50.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miMPM00001, Me.miMPM00002, Me.miMPM00003, Me.MenuItem53, Me.miMPO00001, Me.miMPO00002, Me.miMPO00003, Me.MenuItem55, Me.miMPR00001, Me.miMPR0002, Me.miMPR00003, Me.miMPR00004, Me.miMPR00005, Me.miMPR00006, Me.MenuItem56, Me.miMIM00001, Me.miMIM00002, Me.miSYM00020})
        Me.MenuItem50.Text = "MPO"
        '
        'miMPM00001
        '
        Me.miMPM00001.Enabled = False
        Me.miMPM00001.Index = 0
        Me.miMPM00001.Text = "MPM00001 - Manufacturing Purchase Order Maintenance"
        '
        'miMPM00002
        '
        Me.miMPM00002.Enabled = False
        Me.miMPM00002.Index = 1
        Me.miMPM00002.Text = "MPM00002 - GRN Transfer Maintenance"
        '
        'miMPM00003
        '
        Me.miMPM00003.Enabled = False
        Me.miMPM00003.Index = 2
        Me.miMPM00003.Text = "MPM00003 - Supplier Delivery Maintenance"
        '
        'MenuItem53
        '
        Me.MenuItem53.Index = 3
        Me.MenuItem53.Text = "-"
        '
        'miMPO00001
        '
        Me.miMPO00001.Enabled = False
        Me.miMPO00001.Index = 4
        Me.miMPO00001.Text = "MPO00001 - (WT) Manufacturing Purchase Order Search"
        '
        'miMPO00002
        '
        Me.miMPO00002.Enabled = False
        Me.miMPO00002.Index = 5
        Me.miMPO00002.Text = "MPO00002 - (WT) Manufacturing Purchase Order Generation"
        '
        'miMPO00003
        '
        Me.miMPO00003.Enabled = False
        Me.miMPO00003.Index = 6
        Me.miMPO00003.Text = "MPO00003 - (WT) Manufacturing Purchase Order Approval/Rejection"
        '
        'MenuItem55
        '
        Me.MenuItem55.Index = 7
        Me.MenuItem55.Text = "-"
        '
        'miMPR00001
        '
        Me.miMPR00001.Enabled = False
        Me.miMPR00001.Index = 8
        Me.miMPR00001.Text = "MPR00001 - (WT) Manufacturing Purchase Order Exception Report"
        '
        'miMPR0002
        '
        Me.miMPR0002.Enabled = False
        Me.miMPR0002.Index = 9
        Me.miMPR0002.Text = "MPR00002 - Print Manufacturing Purchase Order"
        '
        'miMPR00003
        '
        Me.miMPR00003.Enabled = False
        Me.miMPR00003.Index = 10
        Me.miMPR00003.Text = "MPR00003 - GRN Transfer Reports"
        '
        'miMPR00004
        '
        Me.miMPR00004.Enabled = False
        Me.miMPR00004.Index = 11
        Me.miMPR00004.Text = "MPR00004 - MPO Item Master Listing"
        '
        'miMPR00005
        '
        Me.miMPR00005.Enabled = False
        Me.miMPR00005.Index = 12
        Me.miMPR00005.Text = "MPR00005 - GRN Transaction List (Adhoc Misc Type Only)"
        '
        'miMPR00006
        '
        Me.miMPR00006.Enabled = False
        Me.miMPR00006.Index = 13
        Me.miMPR00006.Text = "MPR00006 - MPR Transaction Statistics Report"
        '
        'MenuItem56
        '
        Me.MenuItem56.Index = 14
        Me.MenuItem56.Text = "-"
        '
        'miMIM00001
        '
        Me.miMIM00001.Enabled = False
        Me.miMIM00001.Index = 15
        Me.miMIM00001.Text = "MIM00001 - WT Factory Item Master"
        '
        'miMIM00002
        '
        Me.miMIM00002.Enabled = False
        Me.miMIM00002.Index = 16
        Me.miMIM00002.Text = "MIM00002 - Item Master Approval Rejection (WT)"
        '
        'miSYM00020
        '
        Me.miSYM00020.Enabled = False
        Me.miSYM00020.Index = 17
        Me.miSYM00020.Text = "SYM00020 - PRC Item Category Maintenance"
        '
        'MenuItem63
        '
        Me.MenuItem63.Index = 16
        Me.MenuItem63.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSYM00039, Me.miSYM00040, Me.MenuItem66, Me.miQCM00001, Me.miQCM00002, Me.miQCM00003, Me.MenuItem65, Me.miQCM00004, Me.miQCM00009, Me.MenuItem64, Me.miQCM00005, Me.miQCM00006, Me.MenuItem67, Me.miQCM00007, Me.miQCM00010})
        Me.MenuItem63.Text = "QC"
        '
        'miSYM00039
        '
        Me.miSYM00039.Enabled = False
        Me.miSYM00039.Index = 0
        Me.miSYM00039.Text = "SYM00039 - SZ Sales Team Maintenance"
        '
        'miSYM00040
        '
        Me.miSYM00040.Enabled = False
        Me.miSYM00040.Index = 1
        Me.miSYM00040.Text = "SYM00040 - AQL Maintenance"
        '
        'MenuItem66
        '
        Me.MenuItem66.Index = 2
        Me.MenuItem66.Text = "-"
        '
        'miQCM00001
        '
        Me.miQCM00001.Enabled = False
        Me.miQCM00001.Index = 3
        Me.miQCM00001.Text = "QCM00001 - QC Inspection Request Generation"
        '
        'miQCM00002
        '
        Me.miQCM00002.Enabled = False
        Me.miQCM00002.Index = 4
        Me.miQCM00002.Text = "QCM00002 - QC Inspection Request Maintenance"
        '
        'miQCM00003
        '
        Me.miQCM00003.Enabled = False
        Me.miQCM00003.Index = 5
        Me.miQCM00003.Text = "QCM00003 - Release / Unrelease QC Inspection Request"
        '
        'MenuItem65
        '
        Me.MenuItem65.Index = 6
        Me.MenuItem65.Text = "-"
        '
        'miQCM00004
        '
        Me.miQCM00004.Enabled = False
        Me.miQCM00004.Index = 7
        Me.miQCM00004.Text = "QCM00004 - QC Inspection Request Summary"
        '
        'miQCM00009
        '
        Me.miQCM00009.Enabled = False
        Me.miQCM00009.Index = 8
        Me.miQCM00009.Text = "QCM00009 - QC Attachment Maintenance"
        '
        'MenuItem64
        '
        Me.MenuItem64.Index = 9
        Me.MenuItem64.Text = "-"
        '
        'miQCM00005
        '
        Me.miQCM00005.Enabled = False
        Me.miQCM00005.Index = 10
        Me.miQCM00005.Text = "QCM00005 - QC Inspection Request List (Summary)"
        '
        'miQCM00006
        '
        Me.miQCM00006.Enabled = False
        Me.miQCM00006.Index = 11
        Me.miQCM00006.Text = "QCM00006 - QC Inspection Request Check List"
        '
        'MenuItem67
        '
        Me.MenuItem67.Index = 12
        Me.MenuItem67.Text = "-"
        '
        'miQCM00007
        '
        Me.miQCM00007.Enabled = False
        Me.miQCM00007.Index = 13
        Me.miQCM00007.Text = "QCM00007 - QC Report History Summary"
        '
        'miQCM00010
        '
        Me.miQCM00010.Enabled = False
        Me.miQCM00010.Index = 14
        Me.miQCM00010.Text = "QCM00010 - QC Inspection Certificate Report"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 17
        Me.MenuItem22.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem23, Me.MenuItem25, Me.MenuItem5, Me.MenuItem37, Me.MenuItem39, Me.MenuItem59, Me.MenuItem61, Me.MenuItem62, Me.MenuItem36, Me.MenuItem24, Me.MenuItem40, Me.miCOR00001})
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
        Me.MenuItem37.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miMSR00001, Me.miMSR00004, Me.miMSR00012, Me.miMSR00005, Me.miMSR00035})
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
        'miMSR00005
        '
        Me.miMSR00005.Enabled = False
        Me.miMSR00005.Index = 3
        Me.miMSR00005.Text = "MSR00005 - Outstanding Report By Purchase Order"
        '
        'miMSR00035
        '
        Me.miMSR00035.Enabled = False
        Me.miMSR00035.Index = 4
        Me.miMSR00035.Text = "MSR00035 - Outstanding Report (Shipping)"
        '
        'MenuItem39
        '
        Me.MenuItem39.Enabled = False
        Me.MenuItem39.Index = 4
        Me.MenuItem39.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miIMR00019, Me.miINR00011, Me.miSCR00002, Me.miMSR00007, Me.miBSP00004})
        Me.MenuItem39.Text = "Sales Analysis Reports"
        '
        'miIMR00019
        '
        Me.miIMR00019.Enabled = False
        Me.miIMR00019.Index = 0
        Me.miIMR00019.Text = "IMR00019 - External Item Image List (Export to Excel)"
        '
        'miINR00011
        '
        Me.miINR00011.Enabled = False
        Me.miINR00011.Index = 1
        Me.miINR00011.Text = "INR00011 - S/C Summary Report"
        '
        'miSCR00002
        '
        Me.miSCR00002.Enabled = False
        Me.miSCR00002.Index = 2
        Me.miSCR00002.Text = "SCR00002 - Sales Confirmation Analysis Report"
        '
        'miMSR00007
        '
        Me.miMSR00007.Enabled = False
        Me.miMSR00007.Index = 3
        Me.miMSR00007.Text = "MSR00007 - Customer Item History Report"
        '
        'miBSP00004
        '
        Me.miBSP00004.Enabled = False
        Me.miBSP00004.Index = 4
        Me.miBSP00004.Text = "BSP00004 - Sales Analysis By Designer"
        '
        'MenuItem59
        '
        Me.MenuItem59.Enabled = False
        Me.MenuItem59.Index = 5
        Me.MenuItem59.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miINR00004, Me.miINR00010})
        Me.MenuItem59.Text = "Purchases / Production Analysis Reports"
        '
        'miINR00004
        '
        Me.miINR00004.Enabled = False
        Me.miINR00004.Index = 0
        Me.miINR00004.Text = "INR00004 - Production Capacity in CBM Report"
        '
        'miINR00010
        '
        Me.miINR00010.Enabled = False
        Me.miINR00010.Index = 1
        Me.miINR00010.Text = "INR00010 - CBM Ordered Report (Factory Ship-Date)"
        '
        'MenuItem61
        '
        Me.MenuItem61.Enabled = False
        Me.MenuItem61.Index = 6
        Me.MenuItem61.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miINR00013, Me.miINR00012})
        Me.MenuItem61.Text = "Shipping / Invoice Analysis Reports"
        '
        'miINR00013
        '
        Me.miINR00013.Enabled = False
        Me.miINR00013.Index = 0
        Me.miINR00013.Text = "INR00013 - Shipping Summary Report"
        '
        'miINR00012
        '
        Me.miINR00012.Enabled = False
        Me.miINR00012.Index = 1
        Me.miINR00012.Text = "INR00012 - Shipping Schedule Report"
        '
        'MenuItem62
        '
        Me.MenuItem62.Enabled = False
        Me.MenuItem62.Index = 7
        Me.MenuItem62.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miMSR00008})
        Me.MenuItem62.Text = "Sample Order Reports"
        '
        'miMSR00008
        '
        Me.miMSR00008.Enabled = False
        Me.miMSR00008.Index = 0
        Me.miMSR00008.Text = "MSR00008 - Monthly Statement for Sample Charges"
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 8
        Me.MenuItem36.Text = "-"
        '
        'MenuItem24
        '
        Me.MenuItem24.Enabled = False
        Me.MenuItem24.Index = 9
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
        Me.MenuItem40.Index = 10
        Me.MenuItem40.Text = "-"
        '
        'miCOR00001
        '
        Me.miCOR00001.Enabled = False
        Me.miCOR00001.Index = 11
        Me.miCOR00001.Text = "COR00001 - Audit Trail Report"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 18
        Me.MenuItem10.MdiList = True
        Me.MenuItem10.Text = "Windows"
        '
        'lbMenu
        '
        Me.lbMenu.ItemHeight = 12
        Me.lbMenu.Location = New System.Drawing.Point(8, 384)
        Me.lbMenu.Name = "lbMenu"
        Me.lbMenu.Size = New System.Drawing.Size(96, 4)
        Me.lbMenu.TabIndex = 4
        Me.lbMenu.Visible = False
        '
        'ERP00000
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(992, 627)
        Me.Controls.Add(Me.lbMenu)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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

    Private Sub miPOM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPOM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub ERP00000_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Owner.Close()
    End Sub

    Private Sub miSHM00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSHM00007.Click
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

    Private Sub miSYM00033_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00033.Click
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

    Private Sub miSYM00037_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00037.Click
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

    Private Sub miIMX00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMX00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00018_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00018.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMM00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMM00012.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMX00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMX00001.Click
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

    Private Sub miIMX00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMX00007.Click
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

    Private Sub miSCM00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSCM00007.Click
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

    Private Sub miPOM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPOM00002.Click
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

    Private Sub miQUX00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQUX00001.Click
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

    Private Sub miQUA00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQUA00001.Click
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

    Private Sub miSYM00038_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00038.Click
        showForm(sender, Me)
    End Sub

    Private Sub miINR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miINR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPKR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPKR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miACR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miACR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00011_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00011.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGM00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00012.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCLR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCLR00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miCLR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCLR00005.Click
        showForm(sender, Me)
    End Sub


    Private Sub miIMM00015_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMM00015.Click
        showForm(sender, Me)
    End Sub


    Private Sub miMSR00035_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00035.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSHM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSHM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00030_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00030.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSHM00110_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showForm(sender, Me)
    End Sub

    Private Sub miSHR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00009.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00027_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00027.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00036_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00036.Click
        showForm(sender, Me)
    End Sub

    Private Sub miRIR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRIR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00036_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00036.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSHM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSHM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPO00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPO00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPO00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPO00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPO00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPO00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPR0002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPR0002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPR00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPR00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPR00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPR00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMPR00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMPR00006.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMIM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMIM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMIM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMIM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00020_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00020.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPCM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPCM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSMR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSMR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSMR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSMR00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miBSP00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBSP00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miINR00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miINR00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miINR00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miINR00010.Click
        showForm(sender, Me)
    End Sub

    Private Sub miINR00011_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miINR00011.Click
        showForm(sender, Me)
    End Sub

    Private Sub miINR00012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miINR00012.Click
        showForm(sender, Me)
    End Sub

    Private Sub miINR00013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miINR00013.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miMSR00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00007.Click
        showForm(sender, Me)
    End Sub


    Private Sub miMSR00008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMSR00008.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSCR00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSCR00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00002.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00003.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00004.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00005.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00009.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00039_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00039.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00006.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMM00004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMM00004.Click
        showForm(sender, Me)
    End Sub


    Private Sub miPGM00013_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGM00013.Click
        showForm(sender, Me)
    End Sub


    Private Sub miPGX00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGX00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miPGR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPGR00001.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00007.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00040_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00040.Click
        showForm(sender, Me)
    End Sub

    Private Sub miIMR00036_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIMR00036.Click
        showForm(sender, Me)
    End Sub

    Private Sub miSYM00032_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSYM00032.Click
        showForm(sender, Me)
    End Sub

    Private Sub miQCM00010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQCM00010.Click
        showForm(sender, Me)
    End Sub
End Class
