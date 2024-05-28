# PackerFactory

PackerFactory is a collection of libraries and applications developed from April 2016 to November 2021. Its purpose was to automate services for receiving clerk jobs at a factory. This was my first of many jobs and helped me automate a lot of my day-to-day work. Each library targets a specific objective or problem.

## Libraries

### EntityRepository
Defines interfaces for an EntityFramework code-first database handler.

### PackerControlPanel.Core
Provides core model data and structure for receiving process objects and UI creation.

### PackerControlPanel.Data
Implements database interaction and creates infographics based on model data.

### PackerControlPanel.Image
Handles infographics such as box labels, manages user data, and creates receiver entries.

## Applications

### PackerControlPanel.RPCP
Manages part names, job names, receiver, and transfer documents, storing data in SQLite.

### PackerControlPanel.v3.Importer
Command-line tool for importing data from older versions using MySQL. XML exporting/importing is available but not recommended.

### PackerControlPanel.v3.DescMan
Manages part descriptions for older application versions, retained for legacy browsing.

### CommandHandlerLib
Framework for converting methods into command groups, used in older command-line versions.
