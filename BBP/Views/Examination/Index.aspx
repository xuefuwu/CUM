﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    提交考核报告
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>考核任务</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <a class="btn btn-primary" href="/Examination/Create">添加</a>
                    </div>
                    <div class="ibox-content">
                        <table class="table table-striped table-bordered table-hover dataTables">
                            <thead>
                                <tr>
                                    <th>考核对象</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var et in (IEnumerable<BBP.Examination>)Model)
                                   { %>
                                <tr>
                                    <td><%: et.Examinee.Name %></td>
                                    <td><%: Html.ActionLink("编辑", "Edit", new { id=et.ID }) %>|<%: Html.ActionLink("删除", "Delete", new { id=et.ID }) %>|<%:Html.ActionLink("提交整改报告","Create","Feedback",new {ExamId = et.ID},new {}) %>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>考核对象</th>
                                    <th>操作</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(function () {
            $('.dataTables').dataTable();
        });
    </script>
</asp:Content>
