# Moutain
My own learn repository

## Updates 05/13/2025

Switch from master to main.

5 simple steps:

### 1 Move the master branch to main

`git branch --move master main`

### 2 Push main to remote repo

`git push --set-upstream origin main`
### 3 Point HEAD to main branch

`git symbolic-ref refs/remotes/origin/HEAD refs/remotes/origin/main`
### 4 Change default branch to main on GitHub

Navigate in your browser to your GitHub repository.

From the left rail, click Settings -> Branches and change the default branch to main
### 5 Delete master branch on the remote repo

`git push origin --delete master`
