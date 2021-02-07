### Configuration for git
'''
git config --global user.email "dyangcht@aim.com"
git config --global user.name "David Yang"
git config --global credential.username "dyangcht"
'''
### Authorization

'''
git credential fill <ENTER>
protocol=https<ENTER>
host=github.com<ENTER>
<ENTER>
It will prompt a window to ask for auth token
'''


### Check the OAuth scope
'''
curl -H "Authorization: token 88d58291e4b52e9eb155652482b50ec75ea24f96" https://api.github.com/users/dyangcht -I
'''
