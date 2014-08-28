namespace FSXF1

open System
open MonoTouch.UIKit
open MonoTouch.Foundation
open Xamarin.Forms

type App = class
    static member GetMainPage = 
        let lbl = new Label()
        lbl.Text <- "Hello, F# Xam.Forms!"
        lbl.VerticalOptions <- LayoutOptions.CenterAndExpand
        lbl.HorizontalOptions <- LayoutOptions.CenterAndExpand

        let cp = new ContentPage()
        cp.Content <- lbl
        cp

end

[<Register("AppDelegate")>]
type AppDelegate() = 
    inherit UIApplicationDelegate()
    member val Window = null with get, set
    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching(app, options) = 
        this.Window <- new UIWindow(UIScreen.MainScreen.Bounds)
        Forms.Init()
        this.Window.RootViewController <- App.GetMainPage.CreateViewController()
        this.Window.MakeKeyAndVisible()
        true

module Main = 
    [<EntryPoint>]
    let main args = 
        UIApplication.Main(args, null, "AppDelegate")
        0

