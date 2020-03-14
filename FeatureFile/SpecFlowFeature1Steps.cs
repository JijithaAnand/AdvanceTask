using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using static NUnit.Core.NUnitFramework;

namespace MarsFramework.FeatureFile
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I clicked on the Profile page")]
        [Obsolete]
        public void GivenIClickedOnTheProfilePage()
        {
             var Init = new Global.Base();
           
            Init.Inititalize();
            //var Login = new Pages.SignIn();
            Thread.Sleep(1500);
            // Login.Login();
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }

        [When(@"change first and last name")]
        [Obsolete]
        public void WhenChangeFirstAndLastName()
        {
            var profile = new Pages.Profile();
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, profile);
            profile.UpdateProfile();
        }

        [Then(@"the changes should be displayed")]
        [Obsolete]
        public void ThenTheChangesShouldBeDisplayed()
        {
            var Init = new Global.Base();
            //Base.extent();
            Thread.Sleep(1000);
            Base.test = Base.extent.StartTest("Add a First and Last Name");
            //Click on dropdown button
            GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")).Click();
            Thread.Sleep(1500);
            //check first name and Last name

            string FirstName = GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[1]")).GetAttribute("value");
            string LastName = GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[2]")).GetAttribute("value");
            if ((FirstName == "UpdateTest") && (LastName == "Testing12"))
            {
                Global.Base.test.Log(LogStatus.Pass, "Test Passed, Added a First & Last Name Successfully");
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "First and Last Name Addeed");
                Assert.AreEqual(FirstName, "UpdateTest");

            }
           

            Init.TearDown();
        }
        [Given(@"I clicked on the Language tab under Profile page")]
        [Obsolete]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            var Init = new Global.Base();

            Init.Inititalize();
            Thread.Sleep(2500);
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }

        [Given(@"I have logged into skillswap portal Navigate to Profile tab")]
        [Obsolete]
        public void GivenIHaveLoggedIntoSkillswapPortalNavigateToProfileTab()
        {
            var Init = new Global.Base();

            Init.Inititalize();
            Thread.Sleep(2500);
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Path.Combine(Base.ExcelPath, @"TestData.xlsx"), "Language");
            //Add Language
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

            if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "Language Level") == "Basic")
            { 
                GlobalDefinitions.Driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / div / div[2] / select / option[2]")).Click();

            }
            else if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "Language Level") == "Conversational")
            {
                GlobalDefinitions.Driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / div / div[2] / select / option[3]")).Click();
            }
            else if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "Language Level") == "Fluent")
            {
                GlobalDefinitions.Driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / div / div[2] / select / option[4]")).Click();

            }
            else if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "Language Level") == "Native/Bilingual")
            {
                GlobalDefinitions.Driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / div / div[2] / select / option[5]")).Click();
            }
            Thread.Sleep(2000);
            //Click on Add button
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
        }

        [When(@"I click on language to click on edit button for already added language")]
        public void WhenIClickOnLanguageToClickOnEditButtonForAlreadyAddedLanguage()
        {
            Thread.Sleep(1000);
            string ExpectedValue = "English";
            GlobalDefinitions.ExcelLib.PopulateInCollection(Path.Combine(Base.ExcelPath, @"TestData.xlsx"), "Language");
            int count = GlobalDefinitions.Driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")).Count;
            Base.test = Base.extent.StartTest("Edit a Language");
            if (count != 0)
            {
                for (var i = 1; i <= count; i++)
                {

                    Thread.Sleep(500);
                    string ActualValue = GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    if (ExpectedValue == ActualValue)
                    {
                        //Click on edit button
                        GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i")).Click();
                        //Clear language
                        GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input")).Clear();
                        //Add Language
                        GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Language"));
                        //Choose the language level
                        if (Global.GlobalDefinitions.ExcelLib.ReadData(3, "Language Level") == "Basic")
                        {
                            GlobalDefinitions.Driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / table / tbody / tr / td / div / div[2] / select / option[2]")).Click();

                        }
                        else if (Global.GlobalDefinitions.ExcelLib.ReadData(3, "Language Level") == "Conversational")
                        {
                            GlobalDefinitions.Driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / table / tbody / tr / td / div / div[2] / select / option[3]")).Click();
                        }
                        else if (Global.GlobalDefinitions.ExcelLib.ReadData(3, "Language Level") == "Fluent")
                        {
                            GlobalDefinitions.Driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / table / tbody / tr / td / div / div[2] / select / option[4]")).Click();

                        }
                        else if (Global.GlobalDefinitions.ExcelLib.ReadData(3, "Language Level") == "Native/Bilingual")
                        {
                            GlobalDefinitions.Driver.FindElement(By.XPath("/ html / body / div[1] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / table / tbody / tr / td / div / div[2] / select / option[5]")).Click();
                        }
                        //Click on Update button
                        GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")).Click();
                        break;
                    }
                }
            }
        }

        [When(@"I click on language tab and then click on delete button for already added language")]
        public void WhenIClickOnLanguageTabAndThenClickOnDeleteButtonForAlreadyAddedLanguage()
        {
            
            int count = GlobalDefinitions.Driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")).Count;
            string ExpectedValue = "English";
            if (count != 0)
            {
                for (var i = 1; i <= count; i++)
                {
                    Thread.Sleep(1500);
                    string ActualValue = GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    if (ExpectedValue == ActualValue)
                    {
                        //Click on delete button
                        Thread.Sleep(1000);
                        GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();
                        break;
                    }

                }
            }
        }

        [Then(@"that language should be displayed on my listings")]
        [Obsolete]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            var Init = new Global.Base();
            //Start the Reports
            Thread.Sleep(2500);
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            Thread.Sleep(1000);
            Base.test = Base.extent.StartTest("Add a Language");


            string ExpectedValue = "English";
            while (true)
            {
                for (var i = 1; i <= 4; i++)
                {
                    Thread.Sleep(1500);
                    string ActualValue = GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        Global.Base.test.Log(LogStatus.Pass, "Test Passed, Share Skill Added successfully");
                        Thread.Sleep(1500);
                        GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "LanguageAdded");
                        Assert.AreEqual(ActualValue, "English");
                        Init.TearDown();
                        return;
                    }

                }
                Global.Base.test.Log(LogStatus.Fail, "Test failed, Share Skill Not Added successfully");
                Thread.Sleep(1500);
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "LanguageNotAdded");
                Init.TearDown();
            }
            
        }

        [Then(@"the changes for language made should be displayed successfully")]
        public void ThenTheChangesForLanguageMadeShouldBeDisplayedSuccessfully()
        {
            var Init = new Global.Base();
            Thread.Sleep(2500);
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            int check = 0;
            var i = 1;
            Thread.Sleep(1000);
            string ExpectedValues = "Hindi";
            int count = GlobalDefinitions.Driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")).Count;
            Thread.Sleep(2500);
            
            string ActualValue = GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
            if (count != 0)
            {
                for ( i = 1; i <= count; i++)
                {
                    Thread.Sleep(1500);

                    

                    if (ExpectedValues == ActualValue)
                    {
                        Base.test.Log(LogStatus.Pass, "Test Passed, Update a Language Successfully");
                        GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "LanguageUpdated");
                        Assert.Equals(ActualValue, "Hindi");
                        check++;
                        Init.TearDown();
                        return;
                    }
                }
                if (check == 0)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed,Consern Language not found");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "LanguageUpdated");
                    //Assert.Equals(ActualValue, "");
                    Init.TearDown();
                    return;
                }
            }
            else
            {
                Base.test.Log(LogStatus.Pass, "Test Passed, Language is empty");
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "LanguageUpdated");
                //Assert.Equals(ActualValue, "");
                Init.TearDown();
                return;
            }
           
        }

        [Then(@"language should be deleted successufully")]
        public void ThenLanguageShouldBeDeletedSuccessufully()
        {
            Base.test = Base.extent.StartTest("Deleted a Language");
            var Init = new Global.Base();
            Thread.Sleep(2500);
            GlobalDefinitions.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            int check = 0;
            var i =1;
            int counts = GlobalDefinitions.Driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")).Count;
            Thread.Sleep(1000);
            string ExpectedValue = "English";
            String ActualValue = GlobalDefinitions.Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
            if (counts != 0)
            {
                for ( i = 1; i <= counts; i++)
                {
                    
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        Base.test.Log(LogStatus.Fail, "Test Failed, Language Not Deleted");
                        Thread.Sleep(1500);
                        GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "LanguageNotDeleted");
                        Init.TearDown();
                        check++;
                    }
                }
                if (check == 0)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Conserned Language Not found");
                    Thread.Sleep(1500);
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "LanguageDeleted");
                    //Assert.AreEqual(ActualValue,string.Empty);
                    Init.TearDown();
                    return;
                }
               
            }
            else
            {
                Base.test.Log(LogStatus.Pass, "Test Passed,Language is Empty");
                Thread.Sleep(1500);
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "LanguageIsDeletedORLanguageIsEmpty");
                // Assert.AreEqual(ActualValue, "");
                Init.TearDown();
                return;
            }
        }
        [Given(@"Click on ShareSkill button")]
        [Obsolete]
        public void GivenClickOnShareSkillButton()
        {
            var Init = new Global.Base();
            Init.Inititalize();
        }

        [When(@"I Enter fields in ShareSkill")]
        [Obsolete]
        public void WhenIEnterFieldsInShareSkill()
        {
            var theShareSkill = new Pages.ShareSkill();
            theShareSkill.EnterShareSkill();
        }

        [Then(@"that Skill should be Added and viewed successfully")]
        [Obsolete]
        public void ThenThatSkillShouldBeAddedAndViewedSuccessfully()
        {
            var theShareSkill = new Pages.ShareSkill();
            var Init = new Global.Base();
            theShareSkill.viewtheskill();
            Init.TearDown();
        }
        [Given(@"Click on Manage Listing")]
        [Obsolete]
        public void GivenClickOnManageListing()
        {
            var Init = new Global.Base();

            Init.Inititalize();
            var manageListings = new Pages.ManageListings();
            manageListings.ClickManageListing();
        }

        [When(@"Edit the skill in Manage Listing list")]
        [Obsolete]
        public void WhenEditTheSkillInManageListingList()
        {
            var manageListings = new Pages.ManageListings();
            manageListings.EditListing();
        }

        [When(@"Click on the view icon")]
        [Obsolete]
        public void WhenClickOnTheViewIcon()
        {
            var manageListings = new Pages.ManageListings();
            manageListings.ClickView();
        }

        [When(@"Delete the Skill created in manage listing")]
        [Obsolete]
        public void WhenDeleteTheSkillCreatedInManageListing()
        {
            var manageListings = new Pages.ManageListings();
            manageListings.ClickDelete();
        }

        [Then(@"that Skill should be updated successfully")]
        [Obsolete]
        public void ThenThatSkillShouldBeUpdatedSuccessfully()
        {
            var Init = new Global.Base();
            var manageListings = new Pages.ManageListings();
            manageListings.UpdatedSkill();
            Init.TearDown();
        }

        [Then(@"that Skill should be viewed successfully")]
        public void ThenThatSkillShouldBeViewedSuccessfully()
        {
            var Init = new Global.Base();
            Init.TearDown();
        }

        [Then(@"deleted skill should not be available any more")]
        [Obsolete]
        public void ThenDeletedSkillShouldNotBeAvailableAnyMore()
        {
            var Init = new Global.Base();
            
            var manageListings = new Pages.ManageListings();
            manageListings.YesDelete();
            Init.TearDown();
        }
    }
   
}

