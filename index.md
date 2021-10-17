<p align="center">
  <img src="https://user-images.githubusercontent.com/47147484/136712257-bf88799b-f3e8-4102-bf77-91bdf6a9f5b6.png" style="max-width:100%;" height="140" />
</p>

<p align="center">
  <a href="https://gitmoji.carloscuesta.me">
    <img src="https://img.shields.io/badge/gitmoji-%20😜%20😍-FFDD67.svg?style=flat-square" alt="Gitmoji">
  </a> 
</p>

***

## Give a Star 🌟
If you liked the project or if **EasyPermissionManagement** helped you, please give a star.

***

### Purpose
**Easy Permission Management** provides easily permission management on your aspnetcore project.

***

### Supported Databases
- PostgreSQL


### Planned Databases
- [ ] Sql Server
- [ ] MariaDb
- [ ] MySql
- [ ] Mongo
- [ ] SqLite
- [ ] Firebird
- [ ] Oracle

***


## Permission-based Authorization

Typically, applications require more than just authenticated users. We would like to have users with different sets of permissions. The easiest way to achieve this is with the role-based authorization where we allow users to perform certain actions depending on their membership in a role.

For small applications, it might be perfectly fine to use role-based authorization, but this has some drawbacks. For instance, it would be difficult to add or remove roles, because we would have to check every `AuthorizeAttribute` with role specified in our code whenever we changed roles.

More flexible authorization could be implemented using claims. Instead of checking role membership, we check if a user has a permission to perform a certain action. Permission in this case is represented as a claim.

***

### Documentation
Visit [Wiki](https://github.com/furkandeveloper/EasyPermissionManagement/wiki) page for documentation. Lets learn. 👨‍🎓🧐


