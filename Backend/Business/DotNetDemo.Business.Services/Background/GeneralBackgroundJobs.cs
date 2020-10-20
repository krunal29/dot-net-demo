using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Hangfire;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DotNetDemo.Business.Enums.General;
using DotNetDemo.Business.Helpers;
using DotNetDemo.Business.Interfaces.Services.Background;
using DotNetDemo.Business.Models.General;

namespace DotNetDemo.Business.Services.Background
{
    public class GeneralBackgroundJobs : IGeneralBackgroundJobs
    {
        // Call This Function to call Transaction in Audit History Table

        //_backgroundService.EnqueueJob<IGeneralBackgroundJobs>
        //(m => m.AddAuditTrail(ActionTypeEnum.@ActionType, @TransactionSaveId, @OldDataModel, @NewDataModel, 
        //(long)TableEnum.@tableName));

        // if Model Null or no data than passs " (@tableName)Activator.CreateInstance(typeof(@tableName)) "

        #region Audit Trail

        public void AddAuditTrail<T>(
                ActionTypeEnum action, long recordid, T oldObject, T newObject, long? tableId)
        {
            var compObjects = new CompareLogic
            {
                Config = { MaxDifferences = 99, IgnoreCollectionOrder = true,
                        CompareProperties = true, CompareChildren = false }
            };

            ComparisonResult compResult = compObjects.Compare(oldObject, newObject);
            var deltaList = new List<AuditDelta>();
            foreach (var change in compResult.Differences)
            {
                var delta = new AuditDelta();
                if (!string.IsNullOrEmpty(change.PropertyName) && change.PropertyName.Substring(0, 1) == ".")
                {
                    delta.FieldName = change.PropertyName.Substring(1, change.PropertyName.Length - 1);
                }
                delta.ValueBefore = change.Object1Value;
                delta.ValueAfter = change.Object2Value;
                deltaList.Add(delta);
            }
            var jsSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

            // Create AuditHistory Table 
            //var auditTrail = new AuditHistory
            //{
            //    ActionType = (int)action,
            //    TableId = tableId,
            //    CreatedOn = DateTime.UtcNow,
            //    RecordId = recordid,
            //    OldValue = JsonConvert.SerializeObject(oldObject, Formatting.None, jsSettings),
            //    NewValue = JsonConvert.SerializeObject(newObject, Formatting.None, jsSettings),
            //    LogText = JsonConvert.SerializeObject(deltaList, Formatting.None, jsSettings)
            //};

            var obj = JObject.Parse(JsonConvert.SerializeObject(newObject, Formatting.None, jsSettings));
            if (obj != null && CommonHelper.IsNumeric(Convert.ToString(obj["CreatedBy"])))
            {
                var createdby = (long?)obj["CreatedBy"];

                if (createdby != null)
                {
                    //  auditTrail.CreatedBy = createdby;
                }
            }
            //TODO Save Audit History in Database

        }

        #endregion
    }
}
