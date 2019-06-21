using System;
using Gtk;


namespace gtk
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.gtk.gtk", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

           Gtk.Application.Init();

                var window = new Window("Hello Skia World");
                window.SetDefaultSize(1024, 800);
                window.SetPosition(WindowPosition.Center);
                window.DeleteEvent += delegate
                {
                    Gtk.Application.Quit();
                };

                var darea = new CustomDrawing();
                window.Add(darea);

                window.ShowAll();

			Gtk.Application.Run();
        }
    }
}
