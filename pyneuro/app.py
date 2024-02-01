from flask import Flask, request
from textblob import TextBlob
from http.server import BaseHTTPRequestHandler, HTTPServer
from urllib.parse import urlparse, parse_qs

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

class MyRequestHandler(BaseHTTPRequestHandler):
    def do_GET(self):
        parsed_path = urlparse(self.path)
        query_params = parse_qs(parsed_path.query)

        # Set the response headers
        self.send_response(200)
        self.send_header('Content-type', 'text/html')
        self.end_headers()

        msg = query_params["msg"][0]

        # Send the response
        self.wfile.write(analyze_sentiment(msg).encode('utf-8'))

if __name__ == '__main__':
    # Set the port you want to use
    port = 5000

    # Create the server
    server = HTTPServer(('localhost', port), MyRequestHandler)
    print(f"Serving on port {port}")

    # Start the server
    server.serve_forever()