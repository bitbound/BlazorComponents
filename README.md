# Blazor Demo

This app is a compilation of components and services that I frequently bring into new Blazor projects. I thought it would be helpful to have them all in one location. Hopefully it can also be helpful to others who are getting started out with Blazor! :)

There's another tip that didn't quite fit into any category. If you have a large component and want to keep the code cleaner, you can separate the Razor/HTML markup, C#, CSS, and any JS interop calls into nested files. The TreeView component has an example of this. It has TreeView.razor as the top-level file, with TreeView.razor.cs and TreeView.razor.css nested underneath. The C# file will replace the @code block in the Razor file and will be class that inherits ComponentBase. Any styles in the CSS file will be available within the component and should show up in intellisense.

### Demo Summary:

<ul>
    <li>
        Authorization
        <ul>
            <li>
                Use the built-in <code>AuthorizationView</code>, <code>Authorized</code>, and <code>NotAuthorized</code> to show content based on auth state.
            </li>
            <li>
                You can specify a <code>Policy</code> on the <code>AuthorizationView</code>.
            </li>
            <li>
                Use <code>"@attribute [Authorize]"</code> to control access to a whole page.
            </li>
        </ul>
    </li>
    <li>
        Forms
        <ul>
            <li>
                Use <code>AuthorizationView</code>, <code>Authorized</code>, and <code>NotAuthorized</code> to show content based on auth state.
            </li>
            <li>
                You can specify a <code>Policy</code> on the <code>AuthorizationView</code>.
            </li>
            <li>
                Use <code>"@attribute [Authorize]"</code> to control access to a whole page.
            </li>
        </ul>
    </li>
    <li>
        Transitions
        <ul>
            <li>
                Add loading content in <code>#app</code> in <code>index.html</code> for before Blazor loads.
            </li>
            <li>
                Add transitional content in <code>Authorizing</code> and <code>Navigating</code> tags.
            </li>
        </ul>
    </li>
    <li>
        Tabs
        <ul>
            <li>
                Use <code>TabControl</code>, <code>TabHeader</code>, and <code>TabContent</code> to generate a tab control.
            </li>
            <li>
                Use <code>CascadingValue</code> to pass parameters down to child content (e.g. <code>RenderFragment</code>),
                including references to the parent component itself.
            </li>
            <li>
                Bind route params in the <code>"@page"</code> directive to private fields in the code block.
            </li>
        </ul>
    </li>
    <li>
        Modals
        <ul>
            <li>
                Use <code>ModelHarness</code> and <code>ModalService</code> to show modals from C#.
            </li>
            <li>
                Use <code>RenderTreeBuilder</code> to dynamically generate a <code>RenderFragment</code> to pass in as a parameter.
            </li>
        </ul>
    </li>
    <li>
        TreeView
        <ul>
            <li>
                Lets you display hierarchical data.
            </li>
            <li>
                You can pass in type arguments to components.
            </li>
            <li>
                Use <code>"@typeparam T"</code> at the top of the component.
            </li>
        </ul>
    </li>
     <li>
         Toasts
        <ul>
            <li>
                Similar to modals, uses <code>ToastHarness</code> and <code>ToastService</code> to show toasts.
            </li>
        </ul>
    </li>
    <li>
        Alerts
        <ul>
            <li>
                A simple wrapper around Bootstrap alerts, plus an <code>OnClose</code> callback.
            </li>
        </ul>
    </li>
    <li>
        JavaScript Interop
        <ul>
            <li>
                Provides a strongly-typed interface for invoking JavaScript functions via <code>IJSRuntime</code>.
            </li>
            <li>
                Use <code>"@ref"</code> on HTML elements to bind them to <code>ElementReference</code> instances in the
                code block.  These can be passed in as function parameters when invoking through <code>IJSRuntime</code>
                to reference the elements on the JavaScript side.
            </li>
        </ul>
    </li>
</ul>