### Requirements part 1
- Add print methods and validation helpers to helper classes
- Add method for filtering by condition on repository layer
- Add method for getting records by Id
- Add method for updating entities
- Add method for deleting entity by id


### Requirements part 2
- Refactor the code for SOLID principles
- Add Service layer
  - Control menu according to role

---
* Main Menu
  * [Admin] New User
    * Create a new user for the app:
    * Username: _______ -> Read Username ( Must contain at least 5 characters )
    * Password: _______ -> Read Password ( Must contain at least 5 characters and 1 number )
    * Confirm password: _______ -> Read Password confirmation( Must be equal to Password)
    * Role: ( Multiple Choice of 3 roles ) -> Read choice
      * Creation unsuccessful. Please try again -> Restart the New User Section
      * Successful creation of an [Role] user! -> Redirects to Main Menu
  * [Admin] Terminate User
    * Create a new user for the app:
      * Shows all users to pick:
      * Removes the chosen option
  * [Maintenance] List all vehicles -> Lists All Vehicles
    * [Id]) [Model] with License Plate [LicensePlate] and utilized [Percentage of shifts covered]%
  * [Maintenance] License Plate Status -> List All
    * Car Id [Id] - Plate [LicensePlate] expiring on [ExpiryDate]
  * [Manager] List all drivers
    * [Id]) [Full Name] Driving in the [Shift] shift with a [Car.Model] car
  * [Manager] Taxi License Status -> List All
    * Driver [Full Name] with license [License] expiering on [ExpieryDate]
  * [Manager] Driver Manager
    * Assign Unassigned Drivers
      * List of all unasigned drivers
      * Choose one of the drivers that are provided
      * Pick a shift: ( Multiple Choice of 3 shifts ) -> Read Choice
      * Pick Available Car:
        * List available cars ( Cars that have no driver for the picked shift and have a valid license )
        * Choose one of the cars that are provided
    * Unassign Assigned Drivers
      * List of all assigned drivers
      * Choose one of the drivers that are provided
  * [All] Change Password
    * Old Password: _______ -> Read old password
    * New Password: _______ -> Read new password
    * Confirm New Password: ______ -> Read password confirmation
      * Password change unsuccessful. Please try again -> Restart the Change Password Section
      * Successful change password!
  * [All] Exit -> Close Console App
  * [All] Back to Main Menu -> Option available on EVERY menu except the Main Menu