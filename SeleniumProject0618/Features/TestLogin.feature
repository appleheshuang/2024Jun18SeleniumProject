Feature: Login

@TestLogin
  Scenario Outline: Successful Login with valid credentials
    Given the user data from JSON "<Username>" and "<Password>"
    When the user clicks the login button
    #Then the user should be logged in successfully as "<Role>"

    Examples:
      | Username | Password   |
      | admin    | password123|
      | user1    | user1pass  |
      | user2    | user2pass  |
