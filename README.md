# efhbm

## Project Description
This project contains T4 templates to create POCOs + NHibernate mappings from an Entity Framework Model (.edmx).

![efhbm](https://cloud.githubusercontent.com/assets/958768/25091377/1d776c78-2389-11e7-8809-b078916364ef.png)

This can be handy if you like to use the EF modeller but NH as persistence framework, maybe because

- you want to support alternative database types
- you have some legacy NH code and don't want to mix-up NH and EF
- you just like NH-persistence more than EF

This project was created as spike in our team. It's currently not in use, but maybe someone finds it useful for his project. I don't think everything is supported, but you should get the idea.

To use a template, just add it to your project and name it like the model (see sample project)
