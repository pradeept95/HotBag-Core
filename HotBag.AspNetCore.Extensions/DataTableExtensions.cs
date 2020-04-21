﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace HotBag.AspNetCore.Extensions
{
    //public static class DataTableExtensions
    //{
    //    public static List<dynamic> ToDynamicList(this DataTable dt)
    //    {
    //        var list = new List<dynamic>();
    //        foreach (DataRow row in dt.Rows)
    //        {
    //            dynamic dyn = new ExpandoObject();
    //            list.Add(dyn);
    //            foreach (DataColumn column in dt.Columns)
    //            {
    //                var dic = (IDictionary<string, object>)dyn;
    //                dic[column.ColumnName] = row[column];
    //            }
    //        }
    //        return list;
    //    }

    //    public static dynamic[] ToPivotArray<T, TColumn, TRow, TData>(
    //                                                this IEnumerable<T> source,
    //                                                Func<T, TColumn> columnSelector,
    //                                                Expression<Func<T, TRow>> rowSelector,
    //                                                Func<IEnumerable<T>, TData> dataSelector)
    //    {

    //        var arr = new List<object>();
    //        var cols = new List<string>();
    //        String rowName = ((MemberExpression)rowSelector.Body).Member.Name;
    //        var columns = source.Select(columnSelector).Distinct();

    //        cols = (new[] { rowName }).Concat(columns.Select(x => x.ToString())).ToList();


    //        var rows = source.GroupBy(rowSelector.Compile())
    //                         .Select(rowGroup => new
    //                         {
    //                             Key = rowGroup.Key,
    //                             Values = columns.GroupJoin(
    //                                 rowGroup,
    //                                 c => c,
    //                                 r => columnSelector(r),
    //                                 (c, columnGroup) => dataSelector(columnGroup))
    //                         }).ToArray();


    //        foreach (var row in rows)
    //        {
    //            var items = row.Values.Cast<object>().ToList();
    //            items.Insert(0, row.Key);
    //            var obj = GetAnonymousObject(cols, items);
    //            arr.Add(obj);
    //        }
    //        return arr.ToArray();
    //    }

    //    private static dynamic GetAnonymousObject(IEnumerable<string> columns, IEnumerable<object> values)
    //    {
    //        IDictionary<string, object> eo = new ExpandoObject() as IDictionary<string, object>;
    //        int i;
    //        for (i = 0; i < columns.Count(); i++)
    //        {
    //            eo.Add(columns.ElementAt<string>(i), values.ElementAt<object>(i));
    //        }
    //        return eo;
    //    }

    //    public static DataTable ToPivotTable<T, TColumn, TRow, TData>(
    //                                        this IEnumerable<T> source,
    //                                        Func<T, TColumn> columnSelector,
    //                                        Expression<Func<T, TRow>> rowSelector,
    //                                        Func<IEnumerable<T>, TData> dataSelector)
    //    {
    //        DataTable table = new DataTable();
    //        var rowName = ((MemberExpression)rowSelector.Body).Member.Name;
    //        table.Columns.Add(new DataColumn(rowName));
    //        var columns = source.Select(columnSelector).Distinct();

    //        foreach (var column in columns)
    //            table.Columns.Add(new DataColumn(column.ToString()));

    //        var rows = source.GroupBy(rowSelector.Compile())
    //                         .Select(rowGroup => new
    //                         {
    //                             Key = rowGroup.Key,
    //                             Values = columns.GroupJoin(
    //                                 rowGroup,
    //                                 c => c,
    //                                 r => columnSelector(r),
    //                                 (c, columnGroup) => dataSelector(columnGroup))
    //                         });

    //        foreach (var row in rows)
    //        {
    //            var dataRow = table.NewRow();
    //            var items = row.Values.Cast<object>().ToList();
    //            items.Insert(0, row.Key);
    //            dataRow.ItemArray = items.ToArray();
    //            table.Rows.Add(dataRow);
    //        }

    //        return table;
    //    }
    //}
}
