PackerFactory is a collection of libraries and applications that started development in April 2016 and ceased abruptly in November 2021. PackerFactories' purpose was to assist in the automation of services as a receiving clerk at a factory. Each library consists of a specific objective or problem to solve.

# What is everything?
## EntityRepository 
Includes the most basic interfaces to define how an EntityFramework code-first approach database handler should be created and handled.

## PackerControlPanel.Core
The core library contains the base model data used throughout the rest of the libraries. Includes the basic structure of objects used throughout the receiving process, such as part, job, receiver, transfer, and interfaces for handling a database interaction and interfaces for an MVP pattern on UI creation.

## PackerControlPanel.Data
The data library contains the implementation logic of the database interaction by handling the context and worker for an EntityFramework code-first approach. It also implements multiple ways for creating infographics based on model data, like the extraction of a receiver, transfer documents, and infographics on parts and jobs information.

## PackerControlPanel.Image
The image library contains the implementation of handling infographics such as box labels. Other deployments include separating user data by splitting values and creating concrete classes with receiver entries and UI handling.

# Deployements
## PackerControlPanel.RPCP
RPCP or Receiving Packer Control Panel is an application that works on handling part names, job names, creating and storing receiver documents, along the late implementation of transfer documents. Said program also kept important information stored in an SQLite database; previously in an MYSQL Server. Some code changes will be required to change over to a working SQL server.

## PackerControlPanel.v3.Importer
An older deployed version of the application used a command-line interface. This application was used to import version 3 or lower into the newer system, which uses an MYSQL server for the storage of data. XML exporting/importing is still a selectable feature but not recommended.

## PackerControlPanel.v3.DescMan
An older application was used for managing part descriptions from a different source than through PackerControlPanel. This program has no use in the newer versions but is kept in case using or browsing through old versions of PCPV3

## CommandHandlerLib
A small library framework library was created for the plan of turning coded methods into commands. Entire classes can be broken into command groups with ease. This was used in older versions of PCPv2, which used a command-line interface.
