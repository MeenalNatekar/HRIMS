﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AquatroHRIMS.ActionFilters;
using AquatroHRIMS.Models;
using HRIMS;
using AquatroHRIMS.ViewModel;
namespace AquatroHRIMS.Controllers
{
     //[HRIMSActionFilter]
     //[CustomException]
    public class PerformanceController : Controller
    {
        //
        // GET: /Performance/

        QuadrantMeasuresViewModel objQuadrantMeasure = new QuadrantMeasuresViewModel();
        public ActionResult Index()
        {
            try
            {
                int LoginID = Convert.ToInt32(HttpContext.User.Identity.Name);
                List<lstSetQuadMeasures> listQuadMeasure = new List<lstSetQuadMeasures>();
                DataTable dt = cQuadrantMeasure.getEmpQuadratants(LoginID);
                if (aobj.Count > 0)
                {
                    int count = 0;
                    foreach (var item in aobj)
                    {
                        count++;
                        listQuadMeasure.Add(new lstSetQuadMeasures { Count = count, GoalID = item, Measures = item.sMesaures, EmpGoalID = item.iID, empcomment = item.sDescription, GoalName = cGoals.Get_ID(Convert.ToInt32(item.objGoals.iObjectID)).sName, EmpFlag = item.bEmpFlag, ManagerFlag = item.bManagerFlag, ManagerComment = item.sManagerDescription });
                    }
                    objQuadrantMeasure.list1 = list;
                }
                else
                {
                    objQuadrantMeasure.DepartmentTypeModel = getDepartmentTypeID();
                    objQuadrantMeasure.GoalTileModel = getGoalTitleList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           return View(objQuadrantMeasure);
        }
        //Added Swpnesh:-
        [HttpGet]
        public ActionResult AddQuadrants()
        {
            AddQuadrant quadrant = new AddQuadrant();
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(quadrant);
        }
        [HttpPost]
        public JsonResult AddQuadrants(string QuadrantName)
        {
            try
            {
                cGoals goal = cGoals.Create();
                goal.objEmpLogin.iObjectID = Convert.ToInt32(HttpContext.User.Identity.Name);
                goal.sName = QuadrantName.ToString();
                goal.bIsActive = true;
                goal.Save();
                ViewBag.DataSaved = "Goal added successfully";
                return Json("1");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
      
        private SelectList getDepartmentTypeID()
        {
            try
            {
                List<ddlDepartmentTypeList> objDeptTypeList = new List<ddlDepartmentTypeList>();
                List<cDepartmentType> objDeptType = cDepartmentType.Find();
                //objDeptTypeList.Add(new ddlDepartmentTypeList { Value = 0, Text = "--select--" });
                foreach (var item in objDeptType)
                {
                    objDeptTypeList.Add(new ddlDepartmentTypeList { Value = item.iID, Text = item.sName });
                }

                SelectList objDeptTypeListData = new SelectList(objDeptTypeList, "Value", "Text");
                return objDeptTypeListData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private SelectList getGoalTitleList()
        {
            try
            {
                int LoginID = Convert.ToInt32(HttpContext.User.Identity.Name);
                List<ddlGoalTitleList> objGoalTitleList = new List<ddlGoalTitleList>();
                List<cGoals> objGoalTitle = cGoals.Find(" objEmpLogin = " + LoginID);

                foreach (var item in objGoalTitle)
                {
                    objGoalTitleList.Add(new ddlGoalTitleList { Value = item.iID, Text = item.sName });
                }

                SelectList objGoalList = new SelectList(objGoalTitleList, "Value", "Text");
                return objGoalList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public JsonResult GetQuadrantList()
        {
            try
            {
                JsonResult result = new JsonResult();
                //int LoginID = Convert.ToInt32(HttpContext.User.Identity.Name);
                //List<ddlGoalTitleList> objGoalTitleList = new List<ddlGoalTitleList>();
                //List<cGoals> objGoalTitle = cGoals.Find(" objEmpLogin = " + LoginID);
                //foreach (var item in objGoalTitle)
                //{
                //    objGoalTitleList.Add(new ddlGoalTitleList { Value = item.iID, Text = item.sName });
                //}
                //SelectList objGoalList = new SelectList(objGoalTitleList, "Value", "Text");

                QuadrantMeasuresViewModel objQuadrantMeasure = new QuadrantMeasuresViewModel();
                objQuadrantMeasure.DepartmentTypeModel = getDepartmentTypeID();
                objQuadrantMeasure.GoalTileModel = getGoalTitleList();
                result.Data = objQuadrantMeasure;
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
                //return Json(objEmpViewMod);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
	}
}