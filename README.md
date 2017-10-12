# GitLab Label Synchronizer
This small CLI utility makes it easy to synchronize and manage labels in GitLab.

Simply, you can list, create, change, merge, copy, and remove labels between the admin labels, group labels, and project labels.

This utility is built with .NET Core v2 and is supported on Linux, Windows, and Mac. If you discover an issue, please consider contributing to this project, or reporting it [here](https://github.com/chriseaton/gitlab-label-sync/issues).

## Installation

### Option 1: Download Binary

### Option 2: Build From Source

## Operations

### Registering
★ Before you can use any of the commands, you must register your GitLab account. At the moment, only private or personal access tokens may be used.

You may choose to save the credentials to an encrypted local file if you wish using the optional ```--save``` argument
```
gls register {gitlab url} {token} {--save}
```
#### Example
```
gls register https://gitlab.com/chriseaton/gitlab-label-sync 3JKFH2348925NOTREAL4829 --save
```

### Listing Labels
You can list the labels from the admin, a group, or a project, or everything using the ```list``` command argument.

List all labels accessible from your GitLab account.
```
gls list
```
List all admin labels.
```
gls list admin
```
List all labels for a particular project
```
gls list project={project id/path}
```
List all labels for a specific group
```
gls list group={group id/path}
```

### Creating Labels
You can create a label using the ```create``` command argument while passing a ```name``` and optionally ```description``` and ```color```.
```
gls create {admin|project|group}={project|group id/path} name="{name}" description="{description}" color="{hex color}"
```
#### Examples
```
gls create admin name="Failure" description="Something really bad happened." color="#FF0000"
```
```
gls create project=134 name="Report" color="#888800"
```
```
gls create group="core/apps/" name="Help" description="Need help from others"
```

### Changing Labels
You can change any of the three label properties of an existing label using the ```alter``` command argument. An ```id``` is required, however all properties, ```name```, ```description```, or ```color``` are optional.
```
gls alter {id} name="{name}" description="{description}" color="{hex color}"
```
#### Example
```
gls alter 22 name="Bug" description="Something bad happened." color="#FF0000"
```

### Removing Labels
Labels can be cleanly deleted by using the ```remove``` command argument. Labels removed by this tool will also be removed from any issue bearing them so no latent data remains.

When a label is removed from a group, the ```--recursive``` argument may be passed to remove the label from all sub-groups and projects (including issues).

```
gls remove {admin|project|group}={project|group id/path} {id/name} {--recursive}
```
#### Examples
```
gls remove admin "Failure"
```
```
gls remove project=134 453
```
```
gls remove group="core/apps/" "Help"
```

### Clearing Labels
TODO

### Copying Labels
TODO

### Merging Labels
TODO