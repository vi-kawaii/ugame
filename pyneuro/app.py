from flask import Flask, request
from textblob import TextBlob

app = Flask(__name__)

def analyze_sentiment(text):
    # Create a TextBlob object
    blob = TextBlob(text)

    # Get the sentiment polarity (-1 to 1, where -1 is negative, 0 is neutral, and 1 is positive)
    sentiment_polarity = blob.sentiment.polarity

    # Determine sentiment based on the polarity
    if sentiment_polarity > 0:
        return "Positive sentiment"
    elif sentiment_polarity < 0:
        return "Negative sentiment"
    else:
        return "Neutral sentiment"

@app.route('/')
def hello():
    msg = request.args.get('msg')
    return analyze_sentiment(msg)