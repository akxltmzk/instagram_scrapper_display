from instagram import gallery_url
import requests, json
import sys 

username = sys.argv[1]
gallery_url = gallery_url(username)
print(gallery_url)
sys.stdout.flush()