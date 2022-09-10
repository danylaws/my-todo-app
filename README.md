# my-todo-app

This app is a simple ASP[.]Net Core To-Do app, used to show how to deploy an app with Elastic Beanstalk on AWS. The article can be found [here](https://danylaws.hashnode.dev/how-to-deploy-an-aspnet-core-web-app-on-aws-with-elastic-beanstalk).

This app works with a MySQL database. These 3 steps are important to configure the app with the database : 
**Step 1**. Create a MySQL database on your local machine
**Step 2**. update the connection string in the appsettings.json file
**Step 3**. From the app, Run the migrations 
