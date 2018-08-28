# What's On Tap

#### Epicodus C# Group Project, 7/23 - 7/26

#### By Abel Trotter, Elly Maimon, Kevin Ahn and Ryan Murry

## Description

What's On Tap is a web application that displays the different bars in the Portland Metro area and the various beers that are on tap. Users can now see which bars are serving which beers without having to go to the bar. What's on Tap also allows users to maintain a list of their favorite beers, making it easier to find and save your favorite drinks!

## User Stories

* As a user, I am able to make an account and choose between being a regular user or an owner.
* As a user, I am able to see the bars and beers in the Portland area.
* As a user, I am able to add beers to my favorite list.
* As a user, I am able to remove beers from my favorite list.
* As a user, I am able to filter bars and beers by specific categories (rating, neighborhood, etc.)
* As a user, I am able to see the details of the bars and beers.
* As a user, I am able to see where a bar is on a map view.
* As an owner, I am able to edit the information of my bar, and add beers to my taplist.
* As an owner, I am able to remove beers from my taplist.
* As an admin, I am able to create, edit, and delete bars and beers.


## Setup on OSX

* Download and install .Net Core 1.1.4
* Download and install Mono
* Download and install MAMP 4.5
* Clone the repo
* Start MAMP MySQL server
* Run `dotnet restore` from project directory and test directory to install packages
* Run `dotnet build` from project directory and fix any build errors
* Run `dotnet ef database update` to run migrations
* Run `dotnet test` from the test directory to run the testing suite
* Run `dotnet run` to start the server
* Alternatively, run `dotnet watch run` to start the server with the watcher tool

## Setting up User Roles

You will need to run the following SQL script in MySQL to insert the authorization roles into your database:

```
INSERT INTO `AspNetRoles` (`Id`, `ConcurrencyStamp`, `Name`, `NormalizedName`) VALUES ('1', NULL, 'admin', 'admin'), ('2', NULL, 'owner', 'owner'), ('3', NULL, 'user', 'user');
```

## Creating an Admin Account

In order to create an admin, sign up through the application interface for a user account, and then manually set the `RoleId` to `1` in the `AspNetUserRoles` table for the given user.

This can be done through phpMyAdmin, or with the following SQL if you know the `UserId` and the `RoleId` of the account you would like to modify:

```
UPDATE `AspNetUserRoles` SET `RoleId` = '1' WHERE `AspNetUserRoles`.`UserId` = '<user ID here>' AND `AspNetUserRoles`.`RoleId` = '<role ID here>';
```

## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .Net Core 1.1.4
* MAMP 4.5
* MySQL
* Bootstrap 3.3.7
* JavaScript
* jQuery 3.3.1
* jQuery Validate 1.6.0
* jQuery Validation Unobtrusive 3.2.6
* Google Maps API

## Links

* [Github Repo] (https://github.com/atrotter0/whats-on-tap)

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Abel Trotter, Elly Maimon, Kevin Ahn and Ryan Murry**
