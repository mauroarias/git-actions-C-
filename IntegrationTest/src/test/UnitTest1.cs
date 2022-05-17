using System;
using IntegrationTest.test.model;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RA;

namespace IntegrationTest.test;

public class Tests
{
//    private const string ApiUri = "http://localhost:6666"; //to run locally
    private const string ApiUri = "http://projectPoc:80"; //to run inside docker 
    
    [Test, Order(1)]
    public void GivenGetProjectsWhenNoProjectsThenEmptyList()
    {
        new RestAssured()
            .Given()
            .Name("Get projects")
            .Header("Content-Type", "application/json")
            .Header("accept", "text/plain")
            .When()
            .Get(ApiUri+"/project")
            .Then()
            .TestStatus("status OK", i => i == 200)
            .Debug();
    }

    [Test, Order(2)]
    public void GivenPostProjectsWhenProjectWithLicenseThenProjectSaved()
    {
        var project = new Project
        {
            licenseId = Guid.Parse("308bb20c-abb3-4341-b921-f61a546f7b28"),
            name = "name1",
            description = "description1",
            created = DateTime.UtcNow
        };
        new RestAssured()
            .Given()
            .Name("Create project")
            .Header("Content-Type", "application/json")
            .Header("accept", "text/plain")
            .Body(project)
            .When()
            .Post(ApiUri+"/project")
            .Then()
            .TestStatus("status OK", i => i == 200)
            .TestBody("location no null", o => o.location != null)
            .TestBody("location id", o => o.location == "/project/" + o.value.id)
            .AssertAll();
    }

    [Test]
    public void GivenGetProjectsWhenThereAreProjectsThenProjectList()
    {
        new RestAssured()
            .Given()
            .Name("Get projects")
            .Header("Content-Type", "application/json")
            .Header("accept", "text/plain")
            .When()
            .Get(ApiUri+"/project")
            .Then()
            .TestStatus("status OK", i => i == 200)
            .Debug();
    }

    [Test]
    public void GivenGetProjectWhenProjectNoFoundThen404()
    {
        new RestAssured()
            .Given()
            .Name("Get projects")
            .Header("Content-Type", "application/json")
            .Header("accept", "text/plain")
            .When()
            .Get(ApiUri+"/project/b1b5caac-8234-4173-9800-4c610bdbcd36")
            .Then()
            .TestStatus("status OK", i => i == 404)
            .Debug();
    }

    [Test]
    public void GivenPostProjectsWhenProjectWithOutLicenseThenProjectNoSaved()
    {
        var project = new Project
        {
            licenseId = Guid.Parse("21e1ab5b-4247-4624-bd19-dce76eadd757"),
            name = "name2",
            description = "description2",
            created = DateTime.UtcNow
        };
        new RestAssured()
            .Given()
            .Name("Create project")
            .Header("Content-Type", "application/json")
            .Header("accept", "text/plain")
            .Body(project)
            .When()
            .Post(ApiUri+"/project")
            .Then()
            .TestStatus("status OK", i => i == 500)
            .AssertAll();
    }
}