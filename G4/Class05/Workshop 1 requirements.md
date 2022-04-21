## Models
* Base Entity
   * Id
   * Print();
* User
  * Id
  * Username
  * Password
  * Role
    * Administrator
    * Manager
    * Maintenance
* Car
  * Id
  * Model
  * LicensePlate
  * LicensePlateExpiryDate
  * AssignedDrivers
* Driver
  * Id
  * FirstName
  * LastName
  * Shift
    * Morning
    * Afternoon
    * Evening
  * Car
  * License
  * LicenseExpiryDate

Implement classes that will allow the user to interact with a "database" through the UI

Create UI with options

 * Log in
 * Create a user
 * List all vehicles / List all operational vehicles
 * List all drivers
 * Check car expiry licenses
