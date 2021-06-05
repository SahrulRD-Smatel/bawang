using System.Web;
using System.Web.Optimization;

namespace ui.LSP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Content/jquery-ui/jquery-ui.min.js",
                         "~/Scripts/jquery.validate.min.js",
                         "~/Scripts/jquery.validate.unobtrusive.min.js"
                         , "~/Content/moment/moment.min.js"
                         
                         ));
                       

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                "~/Content/fontawesome-free/css/all.min.css",
                //"~/Content/jquery-ui/jquery-ui.min.css",
                "~/Content/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                "~/Content/icheck-bootstrap/icheck-bootstrap.min.css",
                "~/Content/bootstrap-datepicker.min.css",
                //"~/Content/daterangepicker/daterangepicker.css",
                "~/Content/bootstrap-colorpicker/css/bootstrap-colorpicker.min.css",
                "~/Content/bootstrap4-duallistbox/bootstrap-duallistbox.min.css",
                //< !--DataTables-- >
                "~/Content/datatables-bs4/css/dataTables.bootstrap4.min.css",
                "~/Content/datatables-responsive/css/responsive.bootstrap4.min.css",
                "~/Content/datatables-buttons/css/buttons.bootstrap4.min.css",
                "~/Content/dropzone/min/dropzone.min.css",
                "~/Content/bs-stepper/css/bs-stepper.min.css",
                //<!-- Theme style -->
                "~/Content/jqvmap/jqvmap.min.css",
                "~/Content/dist/css/adminlte.min.css",
                "~/Content/overlayScrollbars/css/OverlayScrollbars.min.css",
                "~/Content/daterangepicker/daterangepicker.css",
                "~/Content/summernote/summernote-bs4.min.css",
                "~/Content/select2/css/select2.min.css",
                "~/Content/select2-bootstrap4-theme/select2-bootstrap4.min.css",
                "~/Content/toastr/toastr.css",
                "~/Content/sweetalert2/sweetalert2.min.css",
                "~/Content/dist/css/component-chosen.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Content/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Content/bootstrap-datepicker.id.min.js",
                      //"~/Content/daterangepicker/daterangepicker.js",
                      "~/Content/bootstrap4-duallistbox/jquery.bootstrap-duallistbox.min.js",                      
                      "~/Content/summernote/summernote-bs4.min.js",
                      "~/Content/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                      "~/Content/dist/js/adminlte.js",
                      "~/Content/dist/js/demo.js",
                      "~/Content/dist/js/pages/dashboard.js",
                      //< !--DataTables -->
                      "~/Content/datatables/jquery.dataTables.min.js",
                      "~/Content/datatables-bs4/js/dataTables.bootstrap4.min.js",
                      "~/Content/datatables-responsive/js/dataTables.responsive.min.js",
                      "~/Content/datatables-responsive/js/responsive.bootstrap4.min.js",
                      "~/Content/datatables-buttons/js/dataTables.buttons.min.js",
                      "~/Content/datatables-buttons/js/buttons.bootstrap4.min.js",
                      "~/Content/dropzone/min/dropzone.min.js",
                      "~/Content/jszip/jszip.min.js",
                      "~/Content/datatables-buttons/js/buttons.html5.min.js",
                      "~/Content/datatables-buttons/js/buttons.print.min.js",
                      "~/Content/datatables-buttons/js/buttons.colVis.min.js",
                       "~/Content/toastr/toastr.min.js",
                      "~/Content/sweetalert2/sweetalert2.min.js",
                      "~/Content/dist/js/chosen.jquery.min.js",
                      "~/Content/dist/js/init.js"
                      
                      ));

        }
    }
}
