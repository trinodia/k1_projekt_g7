# Meeting log

##Initial planning meeting conducted 9/12 2015:

###Planned appointments:

Daily stand-up scheduled to weekdays 20.00

Sprint planning/retrospective scheduled to Sundays 20.00

###Initial project time plan:

#####v.50 – Initial planning
  * Preparation – DB setup, create and play with local WCF project, load up planning document/meeting log.

#####v.51 – Sprint 1 
  *	SCRUM master Gustav Nyberg
  *	Sprint planning 13/12 20.00
  *	Item 1-3
  *	Unit testing by developer and code reviewer

#####v.52 – Sprint 2
  *	SCRUM master Daniel Eldström
  *	Sprint planning/retrospective 20/12 20.00
  *	Item 4-8
  *	Unit testing by developer and code reviewer

#####v.53 – Sprint 3
  *	SCRUM master James Enggren
  *	Sprint planning/retrospective 27/12 20.00
  *	Item 9-11
  *	Unit testing by developer and code reviewer

#####v.1 – Final testing and documentation.
  *	Retrospective/Test and deployment planning 3/1 20.00
  *	Acceptance testing and final bug fixes
  *	Delivery at 6/1 23:59

##Retro/Planning meeting conducted 13/12 20:00

####Retrospective
 * Gustav has set up, committed and pushed the foundation for the solution and architecture according to agreement in initial planning. We will use for the development project. It contains a business logic project, data access project, data model project, client project and the service project.
 * Everybody has pulled this solution, set up the database, build the working solution and are ready to start the sprint according to plan.

####Planning
 * We decided to commit to more items then initial planning speed up coding and added the remaining user stories to the weeks sprint.
 * All team members commited to two items each according to the Trello board.

##Retro/Planning meeting conducted 20/12 20:00

####Retrospective
 * Gustav had completed two items
 * James has testing to still do but is otherwise done with his two items
 * Daniel still has one item to start on and another to rewrite
 * A standard has been set for testing and a testing platform with a tool for Google Chrome has been selected

####Planning
 * We decided to speed up coding and added the remaining user stories to the weeks sprint
 * Tests created in the REST test client in Chrome should be exported and added to the GitHub repository when done
 * Two items each were assigned of the remaining user stories and they should be completed before/on 27th December
 * It was decided that the last sprint following this one will be dedicated to refactoring and testing leaving the final days before delivery for finalizing the complete delivery

##Retro/Planning meeting conducted 27/12 20:00

####Retrospective
 * All initial workitems are completed in the trello board
 * Test with exporting/importing from test client in Chrome has been done and is verified to work
 * A problem with debugging the service was resolved and the URI used to call the service were changed to a working one

####Planning
 * UnitTests should be written for the service methods that lacks those
 * We decided to use a unified validation method for the ToDo item that can be called from the methods that takes a ToDo item as input
 * Serverpart of the current client app should be moved out of the client and put in an own Server console application
 * The clientpart of the current client app should remain but be run as an optional part of the solution if needed
 * Help page for the web based part of the service should be updated with descriptions and other information needed for developers implimenting the service
