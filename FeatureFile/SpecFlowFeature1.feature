Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@NonAutomated
    Scenario: Check if user could able to Update Profile
    Given  I clicked on the Profile page
    When change first and last name
    Then the changes should be displayed

@Automated
    Scenario: Check if user could able to add a language 
    Given I clicked on the Language tab under Profile page
    When I add a new language
    Then that language should be displayed on my listings
 
 @Automated
    Scenario: Check if user is able to edit Added language
    Given  I have logged into skillswap portal Navigate to Profile tab
    When I click on language to click on edit button for already added language
    Then the changes for language made should be displayed successfully

@Automated
    Scenario: Check if user is able to delete Added language
    Given  I have logged into skillswap portal Navigate to Profile tab
    When I click on language tab and then click on delete button for already added language
    Then language should be deleted successufully

@Automated
    Scenario: Check if Skill is added using ShareSkill
    Given  Click on ShareSkill button
    When I Enter fields in ShareSkill
    Then that Skill should be Added and viewed successfully

@Automated
    Scenario: Edit Skill in Skill manage Listing
    Given  Click on Manage Listing
    When Edit the skill in Manage Listing list
    Then that Skill should be updated successfully
     
@Automated
    Scenario: View Skill in Manage Listing
    Given  Click on Manage Listing
    When Click on the view icon
    Then that Skill should be viewed successfully
     
@Automated
    Scenario: Delete Skill added in Manage Listing
    Given  Click on Manage Listing
    When Delete the Skill created in manage listing
    Then deleted skill should not be available any more