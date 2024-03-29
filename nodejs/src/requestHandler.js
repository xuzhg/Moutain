var exec = require("child_process").exec;
var querystring = require("querystring"),
    fs = require("fs"),
	formidable = require("formidable");


function start(response) {
	console.log("Request handler 'start' was called.");
	/*
	exec("dir", function(error, stdout, stderr) {
		response.writeHead(200, {"Content-Type": "text/plain"});
		response.write(stdout);
		response.end();
	});	
	*/
		
	var body = '<html>'+
		'<head>'+
		'<meta http-equiv="Context-Type" content="text/html; '+
		'charset=UTF-8" />' +
		'</head>'+
		'<body>'+
		'<form action="/upload" enctype="multipart/form-data" method="post">'+
		'<input type="file" name="upload" multiple="multiple">' +
		'<input type="submit" value="Upload file" />' +
		//'<textarea name="text" rows="20" cols="60"></textarea>'+
		//'<input type="submit" value="Submit text" />'+
		'</form>'+
		'</body>'+
		'</html>';
		
	response.writeHead(200, {"Context-Type": "text/html"});
	response.write(body);
	response.end();	
}

function upload(response, request) {
	console.log("Request handler 'upload' was called.");
	
	var form = new formidable.IncomingForm();
	console.log("about to parse");
	form.parse(request, function(error, fields, files) {
		console.log("parsing done");
		console.log(fields);
		console.log(files.upload.path);
		console.log(files);
		fs.renameSync(files.upload.path, "/tmp/test.png");
		response.writeHead(200, {"Content-Type": "text/html"});
		response.write("received image:<br/>");
		response.write("<img src='/show' />");
		response.end();
	});
	/*
	response.writeHead(200, {"Content-Type": "text/plain"});
	response.write("You've sent the text: " + querystring.parse(postData).text);
	response.end();*/
}

function show(response) {
	console.log("Request handler 'show' was called.");
	fs.readFile("./tmp/02-01-customer-order.png", "binary", function(error, file) {
		if(error) {
			response.writeHead(500, {"Content-Type":"text/plain"});
			response.write(error + "\n");
			response.end();
		} else {
			console.log("file loaded successfully.");
			response.writeHead(200, {"Content-Type":"image/png"});
			response.write(file, "binary");
			response.end;
		}
	});
}

exports.start = start;
exports.upload = upload;
exports.show = show;