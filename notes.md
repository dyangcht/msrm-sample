### Configuration for git
```
git config --global user.email "dyangcht@aim.com"
git config --global user.name "David Yang"
git config --global credential.username "dyangcht"
```
### Authorization

```
git credential fill <ENTER>
protocol=https<ENTER>
host=github.com<ENTER>
<ENTER>
It will prompt a window to ask for auth token
```


### Check the OAuth scope

```
curl -H "Authorization: token xxxxx1e4b52e9edddd52482b50ec7" https://api.github.com/users/dyangcht -I
```
