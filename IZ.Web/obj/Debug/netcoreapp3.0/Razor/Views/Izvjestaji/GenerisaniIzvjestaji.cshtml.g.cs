#pragma checksum "C:\Users\Demir\Documents\Visual Studio 2019\Projects\IzvjestajiZaAgencijuFinal\IzvjestajiZaAgenciju\IZ.Web\Views\Izvjestaji\GenerisaniIzvjestaji.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e85e9bd4942947d2a236f0ae48c7e83acde882d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Izvjestaji_GenerisaniIzvjestaji), @"mvc.1.0.view", @"/Views/Izvjestaji/GenerisaniIzvjestaji.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Demir\Documents\Visual Studio 2019\Projects\IzvjestajiZaAgencijuFinal\IzvjestajiZaAgenciju\IZ.Web\Views\_ViewImports.cshtml"
using IZ.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Demir\Documents\Visual Studio 2019\Projects\IzvjestajiZaAgencijuFinal\IzvjestajiZaAgenciju\IZ.Web\Views\_ViewImports.cshtml"
using IZ.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e85e9bd4942947d2a236f0ae48c7e83acde882d", @"/Views/Izvjestaji/GenerisaniIzvjestaji.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85e9aeacd323c5081a5904015868b23b92d25697", @"/Views/_ViewImports.cshtml")]
    public class Views_Izvjestaji_GenerisaniIzvjestaji : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IZ.Model.VM.ListaSveVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "GET", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DownloadXML", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Izvjestaji", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DownloadExcel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Obrisi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("selekt-tip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Demir\Documents\Visual Studio 2019\Projects\IzvjestajiZaAgencijuFinal\IzvjestajiZaAgenciju\IZ.Web\Views\Izvjestaji\GenerisaniIzvjestaji.cshtml"
  
    ViewData["Title"] = "GenerisaniIzvjestaji";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script type=""text/javascript"">
    $(document).ready(function () {

        $('#tabela').dataTable({
            //""scrollX"": true,
            //select: {
            //style: 'single'
            //},
            //dom: 'Blfrtip',

            language: {
                buttons: {
                    copyTitle: 'Uspjeh',
                    copySuccess: {
                        _: '%d redova kopirano',
                        1: '1 red kopiran'
                    }
                },
                processing: ""Upit se obrađuje..."",
                search: ""Pretraga&nbsp;:"",
                lengthMenu: ""_MENU_ redova"",
                info: ""Prikazano _START_  do _END_ od ukupno _TOTAL_ redova"",
                infoEmpty: ""Nema zapisa..."",
                infoFiltered: ""(filtrirano _MAX_ redova ukupno)"",
                infoPostFix: """",
                loadingRecords: ""Zapisi se učitavaju..."",
                zeroRecords: ""U tabeli je nula redova."",
                emptyT");
            WriteLiteral(@"able: ""Tabela je prazna!"",
                select: {
                    rows: {
                        _: """",
                        0: """",
                        1: """"
                    }
                },
                paginate: {
                    first: ""Prvi"",
                    previous: ""<i class='fas fa-arrow-left'></i>"",
                    next: ""<i class='fas fa-arrow-right'></i>"",
                    last: ""Posljednji""
                },
                aria: {
                    sortAscending: "": "",
                    sortDescending: "": ""
                }
            },
            order: [[0, 'dsc']],
            ajax: {
                ""type"": ""POST"",
                ""url"": ""/Izvjestaji/VratiIzvjestaje"",
                ""data"": function (d) {
                    d.datumOd = $(""#datum-od"").val();
                    d.datumDo = $(""#datum-do"").val();
                    d.definicijaId = $(""#selekt-izv"").val();
                },
                ""dataSrc""");
            WriteLiteral(@": """"
            },
            columns: [
                {
                    data: ""IzvjestajiGenerisaniId"",
                    ""width"": 20,
                    ""className"": 'dt-body-center'
                },
                {
                    data: ""DatumKreiranja"",
                    ""mRender"": function (data, type, full) {
                        return (moment(data).format(""DD-MM-YYYY""));
                    }
                },
                { data: ""NazivXmlfajla"" },
                { data: ""KratkiNazivDefinicijeI"" },
                {
                    data: null,
                    ""orderable"": false,
                    ""searchable"": false,
                    ""className"": 'dt-body-center',
                    ""defaultContent"": '<span class=""d-flex justify-content-around""><a href=""#"" data-toggle=""tooltip"" data-placement=""top"" title=""Generiši XML"" class=""down""><i style=""color:#F8A000;"" class=""material-icons md-fix"">generiši</i></a><a href=""#"" style=""display:none"" st");
            WriteLiteral(@"yle=""color:red"" class=""arhiviraj""><i class=""material-icons md-fix"">clear</i></a></span>'
                },
                {
                    data: null,
                    ""orderable"": false,
                    ""searchable"": false,
                    ""className"": 'dt-body-center',
                    ""defaultContent"": '<span class=""d-flex justify-content-around""><a href=""#"" data-toggle=""tooltip"" data-placement=""top"" title=""Downloaduj excel"" class=""downexc""><i style=""color:#F8A000;"" class=""material-icons md-fix"">download</i></a><a href=""#"" style=""display:none"" style=""color:red"" class=""arhiviraj""><i class=""material-icons md-fix"">clear</i></a></span>'
                },
                {
                    data: null,
                    ""orderable"": false,
                    ""searchable"": false,
                    ""className"": 'dt-body-center',
                    ""defaultContent"": '<span class=""d-flex justify-content-around""><a href=""#"" data-toggle=""tooltip"" data-placement=""top"" title=");
            WriteLiteral(@"""Obriši izvještaj"" class=""obrisi""><i style=""color:#F8A000;"" class=""material-icons md-fix"">obriši</i></a><a href=""#"" style=""display:none"" style=""color:red"" class=""arhiviraj""><i class=""material-icons md-fix"">clear</i></a></span>'
                }
            ]
        });   //kraj tabele

        var table = $('#tabela').DataTable();

        // Primjeni pretragu samo za odabrane kolone
        table.columns([1, 2, 3, 4]).every(function () {
            var that = this;

            $('input', this.footer()).on('keyup change', function () {
                if (that.search() !== this.value) {
                    that
                        .search(this.value)
                        .draw();
                }
            });
        });

        $('#tabela tbody').on('click', 'a.down', function () {
            var ppId = table.row($(this).parents('tr')).data().IzvjestajiGenerisaniId;
            var xmlIme = table.row($(this).parents('tr')).data().NazivXmlfajla;
            $(""#download");
            WriteLiteral(@"d"").val(ppId);
            $(""#xmlIme"").val(xmlIme);
            $('#downloadd').click();
        });

        $('#tabela tbody').on('click', 'a.downexc', function () {
            var xmlNaziv = table.row($(this).parents('tr')).data().ImportedExcel;
            $(""#excel"").val(xmlNaziv);
            $('#excel').click();
        });

        $('#tabela tbody').on('click', 'a.obrisi', function () {
            var ppId = table.row($(this).parents('tr')).data().IzvjestajiGenerisaniId;
            $(""#obrisi"").val(ppId);
            $('#obrisi').click();
        });

        //$("".paginate_button"").css(""background-image"", ""none"");
        //$("".paginate_button"").css(""background-color"", ""white !important"");
        //$("".paginate_button"").css(""border"", ""1px solid grey"");
        //$("".paginate_button"").css(""border-radius"", ""50%"");

    });//kraj ready
</script>


<!-- Pomocna polja -->
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e85e9bd4942947d2a236f0ae48c7e83acde882d12997", async() => {
                WriteLiteral("\r\n    <input id=\"downloadd\" type=\"submit\" name=\"Id\" hidden />\r\n    <input hidden id=\"xmlIme\" name=\"xmlIme\"");
                BeginWriteAttribute("value", " value=\"", 6354, "\"", 6362, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e85e9bd4942947d2a236f0ae48c7e83acde882d15114", async() => {
                WriteLiteral("\r\n    <input id=\"excel\" type=\"submit\" name=\"xmlNaziv\" hidden />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e85e9bd4942947d2a236f0ae48c7e83acde882d17025", async() => {
                WriteLiteral("\r\n    <input id=\"obrisi\" type=\"submit\" name=\"Id\" hidden />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e85e9bd4942947d2a236f0ae48c7e83acde882d18931", async() => {
                WriteLiteral(@"
    <div class=""p-5 border rounded"">
        <div class=""form-group row"">
            <div class=""col-md-3"">
                <label for=""datum-od"" class=""col-form-label"">Datum od:<span class=""obavezno-polje""></span></label>
            </div>
            <div class=""col"">
                <div class=""col-4"">
                    <input id=""datum-od"" class=""form-control"" required />
                    <script>
                        $('#datum-od').datepicker({
                            uiLibrary: 'bootstrap4',
                            format: 'yyyy-mm-dd'
                        }).on('changeDate', function (ev) {
                            $(""select"").trigger(""click"");
                        });
                    </script>
                </div>
            </div>
        </div>

        <div class=""form-group row"">
            <div class=""col-md-3"">
                <label for=""datum-do"" class=""col-form-label"">Datum do:<span class=""obavezno-polje""></span></label>
            ");
                WriteLiteral(@"</div>
            <div class=""col"">
                <div class=""col-4"">
                    <input id=""datum-do"" class=""form-control"" required />
                    <script>
                        $('#datum-do').datepicker({
                            uiLibrary: 'bootstrap4',
                            format: 'yyyy-mm-dd'
                        }).on('changeDate', function (ev) {
                            $(""select"").trigger(""click"");
                        });
                    </script>
                </div>
            </div>
        </div>

        <div class=""form-group row"">
            <div class=""col-3"">
                <label for=""selekt-tip"" class=""col-form-label"">Tip izvještaja:<span class=""obavezno-polje""></span></label>
            </div>
            <div class=""col"">
                <div class=""col-4"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e85e9bd4942947d2a236f0ae48c7e83acde882d21190", async() => {
                    WriteLiteral("\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e85e9bd4942947d2a236f0ae48c7e83acde882d21483", async() => {
                        WriteLiteral("Odaberite");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 207 "C:\Users\Demir\Documents\Visual Studio 2019\Projects\IzvjestajiZaAgencijuFinal\IzvjestajiZaAgenciju\IZ.Web\Views\Izvjestaji\GenerisaniIzvjestaji.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(ViewBag.SelektTip,"text1","text2"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class=""form-group row"">
            <div class=""col-3"">
                <label for=""selekt-izv"" class=""col-form-label"">Izvještaj:<span class=""obavezno-polje""></span></label>
            </div>
            <div class=""col"">
                <div class=""col-4"">
                    <select id=""selekt-izv"" class=""form-control"">
                    </select>
                </div>
            </div>
        </div>

        <div class=""form-group row"">
            <div class=""col-6"">
                <button id=""prikazi"" type=""button"" class=""row btn btn-success"" style=""float: right; margin-top:5px; margin-right:1px"">Prikaži izvještaje</button>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<br />\r\n<div class=\"col-12\">\r\n    <div style=\"width:100%\">\r\n");
            WriteLiteral(@"        <table id=""tabela"" class=""table table-hover full-width"">
            <thead>
                <!-- atributi tabele -->
                <tr>
                    <th>#</th>
                    <th>Datum kreiranja</th>
                    <th>Naziv XML fajla</th>
                    <th>Kratki naziv definicije</th>
                    <th class=""akcije"">Generiši XML</th>
                    <th class=""akcije"">Download Excel</th>
                    <th class=""akcije"">Obriši</th>
                </tr>
            </thead>
            <tfoot>
                <!-- pretraga futer -->
                <tr>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
");
            WriteLiteral("                    <th></th>\r\n                    <th></th>\r\n                </tr>\r\n            </tfoot>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            var items = ""<option value='0'>Odaberite</option>"";
            $(""#selekt-izv"").html(items);
        });

        $(""#selekt-tip"").change(function () {
            var tipId = $(""#selekt-tip"").val();
            var url = ""/Izvjestaji/VratiIzvjestajePoTipu"";

            $.getJSON(url, { tipId: tipId }, function (data) {
                var item = """";
                item = '<option value=""0"">Odaberite</option>'
                $(""#selekt-izv"").empty();
                if (data != undefined) {
                    for (i = 0; i < data.length; i++) {
                        item += '<option value=""' + data[i].text1 + '"">' + data[i].text2 + '</option>'
                    }
                }
                else {
                    item = '<option value=""0"">Nema izvještaja</option>'
                }
                $(""#selekt-izv"").html(item);
            });
        });

        $(""#prikazi"").");
                WriteLiteral(@"click(function () {
            var table = $('#tabela').DataTable();
            table.ajax.reload();
            // var definicijaId = $(""#selekt-izv"").val();
            // var datumOd =$(""#datum-od"").val();
            // var datumDo =  $(""#datum-do"").val();
            //var url = ""/Izvjestaji/VratiIzvjestaje"";

            //$.getJSON(url, {datumOd: datumOd, datumDo : datumDo, definicijaId: definicijaId}, function (data) {
            //    var item = """";

            //    if (data != undefined) {
            //        console.log(data)
            //        table.ajax(data);
            //    }
            //    else {
            //        item = '<option value=""0"">Nema izvještaja</option>'
            //    }
            //    $(""#selekt-izv"").html(item);
            //});
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IZ.Model.VM.ListaSveVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
