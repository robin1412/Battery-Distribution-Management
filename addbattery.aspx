<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addbattery.aspx.cs" Inherits="webapp1.addbattery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Batteries4u</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Font Awesome -->
    <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
    <!-- Google Font: Source Sans Pro -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body class="hold-transition sidebar-mini layout-fixed">
    <form id="form1" runat="server">
        <div class="wrapper">

            <nav class="main-header navbar navbar-expand navbar-white navbar-light">
                <!-- Left navbar links -->
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
                    </li>
                    <li class="nav-item d-none d-sm-inline-block">
                        <a href="distributer_panel.aspx" class="nav-link">Home</a>
                    </li>
                    <li class="nav-item d-none d-sm-inline-block">
                        <a href="#" class="nav-link">Contact</a>
                    </li>
                </ul>

                <div class="offset-sm-8">
                    <asp:Button ID="Button2" runat="server" Text="Logout" class="btn btn-primary btn-block" OnClick="Button2_Click" />

                </div>

                <!-- Right navbar links -->

            </nav>
            <!-- /.navbar -->
            <aside class="main-sidebar sidebar-dark-primary elevation-4">
                <a href="#" class="brand-link">
                    <img src="../../dist/img/AdminLTELogo.png"
                        alt="AdminLTE Logo"
                        class="brand-image img-circle elevation-3"
                        style="opacity: .8">
                    <span class="brand-text font-weight-light">Batteries for U</span>
                </a>

                <!-- Sidebar -->
                <div class="sidebar">
                    <div class="user-panel mt-3 pb-3 mb-3 d-flex">
                        <div class="image">
                            <img src="../../dist/img/user2-160x160.jpg" class="img-circle elevation-2" alt="User Image">
                        </div>

                        <div class="info">
                            <a class="d-block">
                                <asp:Label ID="Label1" runat="server"></asp:Label></a>
                        </div>
                    </div>

                    <!-- Sidebar Menu -->
                    <nav class="mt-2">
                        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                            <!-- Add icons to the links using the .nav-icon class
               with font-awesome or any other icon font library -->
                            <li class="nav-item has-treeview">
                                <a class="nav-link">
                                    <i class="nav-icon fas fa-tachometer-alt"></i>
                                    <p>
                                        My Account
                <i class="right fas fa-angle-left"></i>
                                    </p>
                                </a>
                                <ul class="nav nav-treeview">
                                    <li class="nav-item">
                                        <a href="addbattery.aspx" class="nav-link">
                                            <i class="nav-icon fas fa-edit"></i>
                                            <p>Add new Battery</p>
                                        </a>
                                    </li>

                                    <li class="nav-item">
                                        <a href="newpurchase.aspx" class="nav-link">
                                            <i class="nav-icon fas fa-edit"></i>
                                            <p>Add Purchase Details</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="showpurchase.aspx" class="nav-link">
                                            <i class="nav-icon fas fa-table"></i>
                                            <p>Show purchase</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="addstock.aspx" class="nav-link">
                                            <i class="nav-icon fas fa-edit"></i>
                                            <p>Add Stock</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="showstock.aspx" class="nav-link">
                                            <i class="nav-icon fas fa-table"></i>
                                            <p>Show Stock</p>
                                        </a>
                                    </li>
                                </ul>
                            </li>


                        </ul>
                    </nav>
                    <!-- /.sidebar-menu -->
                </div>
                <!-- /.sidebar -->
            </aside>

            <div class="content-wrapper">
                <section class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-6">
                                <h1>Add New Battery</h1>
                            </div>
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </section>
                <!-- left column -->
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                 </asp:ScriptManager>
                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-sm-2 col-form-label">Company Name</div>
                        <div class="col-6">
                            <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Enter company name" ></asp:TextBox>
                          
                          
                        </div>
                    </div>
                    <br/>
                    <div class="row">
                        <div class="col-2">Model Name</div>
                        <div class="col-6">
                            <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Enter Model Name"></asp:TextBox>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-2">Model Number</div>
                        <div class="col-6">
                            <asp:TextBox ID="TextBox3" class="form-control" runat="server" placeholder="Enter Model Number"></asp:TextBox>
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-2">Category</div>
                        <div class="col-6">
                            <asp:TextBox ID="TextBox4" class="form-control" runat="server" placeholder="Enter category"></asp:TextBox>
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-2">Capacity</div>
                        <div class="col-6">
                            <asp:TextBox ID="TextBox5" class="form-control" runat="server" placeholder="Enter capacity"></asp:TextBox>
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-2">Price</div>
                        <div class="col-6">
                            <asp:TextBox ID="TextBox6" class="form-control" runat="server" placeholder="Enter warrenty months"></asp:TextBox>
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-2">Warrenty</div>
                        <div class="col-6">
                            <asp:TextBox ID="TextBox7" class="form-control" runat="server" placeholder="Enter price"></asp:TextBox>
                        </div>
                    </div>
                    <br>
                    <asp:Button ID="Button1" class="btn btn-block btn-primary" runat="server" Text="Add" Width="100px" OnClick="Button1_Click1" />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </div>
            </div>

            <!-- left column -->
            <footer class="main-footer">
                <div class="float-right d-none d-sm-block">
                </div>
                <strong>Copyright &copy; 2020 <a href="#">Fabulous 5</a>.</strong> All rights
    reserved.
            </footer>

            <!-- Control Sidebar -->
            <aside class="control-sidebar control-sidebar-dark">
                <!-- Control sidebar content goes here -->
            </aside>
            <!-- /.control-sidebar -->

        </div>
    </form>
    <script src="../../plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../../dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../../dist/js/demo.js"></script>
</body>
</html>
