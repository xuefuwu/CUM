<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑考核对象类型
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <link href="/css/plugins/jQueryUI/jquery-ui-1.10.4.custom.min.css" rel="stylesheet">

    <!-- Data Tables -->
    <link href="/css/plugins/jqgrid/ui.jqgrid.css" rel="stylesheet">
    <style>
        /* Additional style to fix warning dialog position */
        #alertmod_table_attrs {
            top: 900px !important;
        }
    </style>
    <% BBP.ExamineeType et = (BBP.ExamineeType)Model; %>
    <div class="col-md-12">
        <input type="hidden" id="ID" name="ID" class="form-control" placeholder="请输入文本" value="<%:et.ID %>">
        <div class="form-group">
            <label class="col-sm-3 control-label">考核对象模型名称：</label>
            <div class="col-sm-9">
                <input type="text" id="TypeName" name="TypeName" class="form-control" placeholder="请输入文本" value="<%:et.TypeName %>">
            </div>
        </div>

        <div class="jqGrid_wrapper">
            <table id="table_attrs"></table>
            <div id="pager_attrs"></div>
        </div>
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    创建考核对象模型
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ExtendContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <% BBP.ExamineeType et = (BBP.ExamineeType)Model; %>
    <!-- jqGrid -->
    <script src="/js/plugins/jqgrid/i18n/grid.locale-cn.js"></script>
    <script src="/js/plugins/jqgrid/jquery.jqGrid.min.js"></script>

    <script>
        $(document).ready(function() {
            var lastsel2;
            var selectdata = {
            
            };
            $.ajax({
                url: "/Admin/ExamineeType/GetSelectData",
                type: "POST",
                dataType: "json",
                async: false,
                success: function(data) {
                    if (data.result = "True") {
                        selectdata = JSON.parse(data);
                    }
                }
            });
            var mydata = [
                {
                    "ValueType": 1,
                    "AttrName": "Name",
                    "AttrText": "名称"
                }
            ];
            // 
            $("#table_attrs")
                .jqGrid({
                    url: '/Admin/ExamineeType/GetTableData?typeId=<%:et.ID%>',
                    datatype: "json",
                    mtype: 'POST',
                    height: 450,
                    autowidth: true,
                    shrinkToFit: true,
                    rowNum: 20,
                    rowList: [10, 20, 30],
                    colNames: ['序号', '字段类型', '字段名称', '字段标题', '值', '排序'],
                    colModel: [
                        {
                            name: 'ID',
                            index: 'ID',
                            width: 60,
                            sorttype: "int",
                            search: true
                        },
                        {
                            name: 'ValueType',
                            index: 'ValueType',
                            editable: true,
                            edittype: "select",
                            editoptions: {
                                value: selectdata
                            },
                            formatter: function(cellvalue, options, rowObject) {
                                var valueType = "";
                                if (cellvalue.constructor == String) {
                                    valueType = cellvalue;
                                } else {
                                    switch (cellvalue.ID) {
                                    case 1:
                                        valueType = "数字";
                                        break;
                                    case 2:
                                        valueType = "文本";
                                        break;
                                    case 3:
                                        valueType = "布尔";
                                        break;
                                    case 4:
                                        valueType = "单选";
                                        break;
                                    case 5:
                                        valueType = "复选";
                                        break;
                                    default:
                                        valueType = "文本";
                                    }
                                }
                                return valueType;
                            },
                            width: 90
                        },
                        {
                            name: 'AttrName',
                            index: 'AttrName',
                            editable: true,
                            width: 100
                        },
                        {
                            name: 'AttrText',
                            index: 'AttrText',
                            editable: true,
                            width: 80
                        },
                        {
                            name: 'AttrValue',
                            index: 'AttrValue',
                            editable: true,
                            sortable: false,
                            edittype: "textarea",
                            editoptions: { rows: "2", cols: "20" },
                            formoptions: { elmsuffix: "<br />每一行一个选项" }
                        },
                        {
                            name: 'SortBy',
                            index: 'SortBy',
                            editable: true,
                            editopions:{defaultValue:0},
                            sorttype: 'int',
                            sortable: true,
                            width: 80
                        }
                    ],
                    onSelectRow: function(id) {
                        if (id && id !== lastsel2) {
                            jQuery('#table_attrs').jqGrid('restoreRow', lastsel2);
                            jQuery('#table_attrs').jqGrid('editRow', id, true);
                            lastsel2 = id;
                        }
                    },
                    pager: '#pager_attrs',
                    viewrecords: true,
                    caption: '考核对象模型字段',
                    editurl: '/Admin/ExamineeType/RowEditing',
                    hidegrid: false
                });
            // Setup buttons
            $("#table_attrs")
                .jqGrid('navGrid',
                    '#pager_attrs',
                    {
                        edit: false,
                        add: false,
                        del: false,
                        search: false
                    })
                .navButtonAdd('#pager_attrs',
                {
                    caption: "",
                    buttonicon: "ui-icon-plus",
                    onClickButton: function() {
                        $("#table_attrs")
                            .jqGrid('editGridRow',
                                "new",
                                {
                                    reloadAfterSubmit: false
                                });
                    },
                    position: "first"
                })
                .navButtonAdd('#pager_attrs',
                {
                    caption: "",
                    buttonicon: "ui-icon-trash",
                    onClickButton: function() {
                        var selectedId = $("#table_attrs").jqGrid("getGridParam", "selrow");
                        if (!selectedId) {
                            alert("请选择要删除的行");
                            return;
                        } else {
                            var rowData = $("#table_attrs").jqGrid('getRowData', selectedId);
                            $.ajax({
                                url: "/Admin/ExamineeType/RowDelete?eaid=" + rowData.ID,
                                type: "POST",
                                async: false
                            });
                            $("#table_attrs")
                                .jqGrid("delRowData",
                                    selectedId,
                                    {
                                        reloadAfterSubmit: true
                                    });
                        }
                    },
                    position: "last"
                });
            // Add responsive to jqGrid
            $(window)
                .bind('resize',
                    function() {
                        var width = $('.jqGrid_wrapper').width();
                        $('#table_attrs').setGridWidth(width);
                    });

            $(".btn-submit")
                .click(function() {
                    //$("form").attr("action", "/Admin/ExamineeType/Create");
                    //$("form").submit();
                    var JsonArray = new Array();
                    var obj = $("#table_attrs").jqGrid("getRowData");
                    $(obj)
                        .each(function() {

                            var rowdata = {
                                "ValueType": {
                                    "ID": getKey(selectdata, this.ValueType),
                                    "ValueTypeName": this.ValueType
                                },
                                "AttrName": this.AttrName,
                                "AttrText": this.AttrText,
                                "AttrValue": this.AttrValue,
                                "SortBy": this.SortBy
                            };
                            if (this.ID != "") {
                                rowdata["ID"] = this.ID;
                            }
                            JsonArray.push(rowdata);
                        });
                    var s = { ID: $("#ID").val(), TypeName: $("#TypeName").val(), ExTAttrs: JsonArray };
                    alert(JSON.stringify(s));
                    $.ajax({
                        type: "POST",
                        url: "/Admin/ExamineeType/Edit",
                        data: { examineeType: String.toSerialize(s) },
                        dataType: 'json',
                        async: false,
                        success: function(responseData) {
                            alert(responseData);
                        },
                        error: function(xmlHttpRequest, textStatus, errorThrown) {
                            console.log("请求失败，无法获取分组数据");
                        }
                    });

                });

        });
        function getKey(data, value) {
            var rtn;
            for (key in data) {
                if (data[key] == value) {
                    rtn = key;
                }
            }
            return rtn;
        }
        /*对象序列化为字符串*/
        String.toSerialize = function (obj) {
            var ransferCharForJavascript = function (s) {
                var newStr = s.replace(
                /[\x26\x27\x3C\x3E\x0D\x0A\x22\x2C\x5C\x00]/g,
                function (c) {
                    ascii = c.charCodeAt(0)
                    return '\\u00' + (ascii < 16 ? '0' + ascii.toString(16) : ascii.toString(16));
                }
                );
                return newStr;
            }
            if (obj == null) {
                return null;
            }
            else if (obj.constructor == Array) {
                var builder = [];
                builder.push("[");
                for (var index in obj) {
                    if (typeof obj[index] == "function") continue;
                    if (index > 0) builder.push(",");
                    builder.push(String.toSerialize(obj[index]));
                }
                builder.push("]");
                return builder.join("");
            }
            else if (obj.constructor == Object) {
                var builder = [];
                builder.push("{");
                var index = 0;
                for (var key in obj) {
                    if (typeof obj[key] == "function") continue;
                    if (index > 0) builder.push(",");
                    builder.push(String.format("\"{0}\":{1}", key, String.toSerialize(obj[key])));
                    index++;
                }
                builder.push("}");
                return builder.join("");
            }
            else if (obj.constructor == Boolean) {
                return obj.toString();
            }
            else if (obj.constructor == Number) {
                return obj.toString();
            }
            else if (obj.constructor == String) {
                return String.format('"{0}"', ransferCharForJavascript(obj));
            }
            else if (obj.constructor == Date) {
                return String.format('{"__DataType":"Date","__thisue":{0}}', obj.getTime() - (new Date(1970, 0, 1, 0, 0, 0)).getTime());
            }
            else if (this.toString != undefined) {
                return String.toSerialize(obj);
            }
        }
        String.format = function () {

            if (arguments.length == 0) {
                return null;
            }

            var str = arguments[0];

            for (var i = 1; i < arguments.length; i++) {

                var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
                str = str.replace(re, arguments[i]);
            }
            return str;
        }
    </script>
</asp:Content>
