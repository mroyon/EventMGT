var fontName = "";
$(document).ready(function () {
    
    $.ajax({
        url: '../fonts/fontname.txt', // Path to the text file
        method: 'GET',
        success: function (response) {
            // Get the first line of the text file
            fontName = response.split('\n')[0].trim(); // Split by new line and get the first line
            //console.log(fontName)

            tinymce.init({

                font_formats:
                    "SutonnyMJ=SutonnyMJ;AdarshaLipiNormal=AdarshaLipiNormal;Solaimanlipi=Solaimanlipi;Kalpurush=Kalpurush;SutonnyEMJ=SutonnyEMJ;SulekhaT=SulekhaT;  Andale Mono=andale mono,times; Arial=arial,helvetica,sans-serif; Arial Black=arial black,avant garde; Book Antiqua=book antiqua,palatino; Comic Sans MS=comic sans ms,sans-serif; Courier New=courier new,courier; Georgia=georgia,palatino; Helvetica=helvetica; Impact=impact,chicago; Symbol=symbol; Tahoma=tahoma,arial,helvetica,sans-serif; Terminal=terminal,monaco; Times New Roman=times new roman,times; Trebuchet MS=trebuchet ms,geneva; Verdana=verdana,geneva; Webdings=webdings; Wingdings=wingdings,zapf dingbats",
                mode: "textareas",
                directionality: dir,
                base_url: '/lib/tinymce',
                skin: 'oxide-dark',
                //content_css: 'dark',
                content_css: 'white',
                //menubar: false,
                menubar: 'file edit view insert format tools table help',
                statusbar: false,
                toolbar: 'undo redo | bold italic underline strikethrough | fontselect fontsizeselect formatselect | alignleft aligncenter alignright alignjustify | outdent indent |  numlist bullist checklist | forecolor backcolor casechange permanentpen formatpainter removeformat | pagebreak | charmap emoticons | fullscreen  preview save print | insertfile image media pageembed template link anchor codesample | a11ycheck ltr rtl | showcomments addcomment | code ',
                quickbars_selection_toolbar: 'bold italic | quicklink h2 h3 blockquote quickimage quicktable',
                //plugins: [
                //    'advlist autolink lists link image charmap print preview anchor', 
                //    'searchreplace visualblocks code fullscreen',
                //    'insertdatetime media table paste code help wordcount',
                //    'emoticons hr pagebreak nonbreaking',
                //    'charmap quickbars save autoresize'
                //], 
                //toolbar: `undo redo | fontselect fontsizeselect formatselect | bold italic underline strikethrough backcolor |
                //        alignleft aligncenter alignright alignjustify | bullist numlist outdent indent checklist |
                //        forecolor backcolor casechange permanentpen formatpainter removeformat | link image media | code fullscreen`,

                height: 500,
                plugins: 'paste fullscreen',
                paste_as_text: false,
                //paste_webkit_styles: 'color font-weight font-style', // Only retain these styles
                //paste_retain_style_properties: 'color font-weight font-style',
                //valid_elements: 'p,strong,em,br',
                // forced_root_block: 'p',
                //forced_root_block: "",
                setup: function (editor) {
                    editor.on('change', function () {
                        tinymce.triggerSave();
                        //validateRequiredfldTM();
                    });
                    editor.on('init', function () {


                        // Ensure SutonnyMJ is the default font when the editor is initialized
                        //editor.getBody().style.fontFamily = 'SutonnyMJ';

                        $.ajax({
                            url: '../fonts/fontname.txt', // Path to the text file
                            method: 'GET',
                            success: function (response) {
                                // Get the first line of the text file
                                var fontName = response.split('\n')[0].trim(); // Split by new line and get the first line
                                console.log(editor.settings.font_formats);
                                editor.getBody().style.fontFamily = fontName;
                                //editor.settings.font_formats = 

                                //console.log(editor.settings.font_formats);
                            },
                            error: function () {
                                console.error('Error loading font from file.');
                            }
                        });
                    });
                    editor.on('paste', function (e) {
                        let pastedData = e.clipboardData.getData('text'); // Get the plain text from the clipboard
                        console.log(pastedData)
                        var t = "bijoy";
                        //var w = pastedData;
                        var content1 = pastedData;//$('#hdneventdescription').val();
                        console.log(content1)
                        var str = content1.replace(/^\<p\>/, "").replace(/\<\/p\>$/, "");
                        //w = cM(t, w);
                        content1 = cM(t, str);

                        //content1 = cleanText(content1);
                        var wrappedContent = content1.split('\n').map(function (line) {
                            return '<p>' + line + '</p>';  // Wrap each line in <p> tags
                        }).join('');  // Join lines back together as HTML

                        if (wrappedContent) {
                            wrappedContent = wrappedContent.replace(/<p>&nbsp;<\/p>/g, '');
                        }
                        let cleanedText = wrappedContent.replace(/<p><br data-mce-bogus="1"><\/p>/g, '');

                        var cleanedContent = wrappedContent.replace(/<p>&nbsp;<\/p>/g, '');
                        console.log(cleanedContent)
                        e.preventDefault(); // Prevent the default paste behavior
                        cleanedContent = cleanedContent.replace(/<p><br data-mce-bogus="1"><\/p>/g, '');
                        editor.insertContent(cleanedContent); // Insert modified content into the editor
                    });

                    // Automatically remove <p>&nbsp;</p> when the content is modified or set
                    //editor.on('SetContent', function () {
                    //    var content = editor.getContent();  // Get the current content
                    //    var cleanedContent = content.replace(/<p>&nbsp;<\/p>/g, '');  // Remove all <p>&nbsp;</p>
                    //    editor.setContent(cleanedContent);  // Set the cleaned content back into the editor
                    //});
                }
            });
        },
        error: function () {
            console.error('Error loading font from file.');
        }
    });

    //tinymce.init({

    //    font_formats:
    //        "SutonnyMJ=SutonnyMJ;AdarshaLipiNormal=AdarshaLipiNormal;Kalpurush=Kalpurush;SutonnyEMJ=SutonnyEMJ;SulekhaT=SulekhaT;  Andale Mono=andale mono,times; Arial=arial,helvetica,sans-serif; Arial Black=arial black,avant garde; Book Antiqua=book antiqua,palatino; Comic Sans MS=comic sans ms,sans-serif; Courier New=courier new,courier; Georgia=georgia,palatino; Helvetica=helvetica; Impact=impact,chicago; Symbol=symbol; Tahoma=tahoma,arial,helvetica,sans-serif; Terminal=terminal,monaco; Times New Roman=times new roman,times; Trebuchet MS=trebuchet ms,geneva; Verdana=verdana,geneva; Webdings=webdings; Wingdings=wingdings,zapf dingbats",

    //    mode: "textareas",
    //    directionality: dir,
    //    base_url: '/lib/tinymce',
    //    skin: 'oxide-dark',
    //    //content_css: 'dark',
    //    content_css: 'white',
    //    //menubar: false,
    //    menubar: 'file edit view insert format tools table help',
    //    statusbar: false,
    //    toolbar: 'undo redo | bold italic underline strikethrough | fontselect fontsizeselect formatselect | alignleft aligncenter alignright alignjustify | outdent indent |  numlist bullist checklist | forecolor backcolor casechange permanentpen formatpainter removeformat | pagebreak | charmap emoticons | fullscreen  preview save print | insertfile image media pageembed template link anchor codesample | a11ycheck ltr rtl | showcomments addcomment | code ',
    //    quickbars_selection_toolbar: 'bold italic | quicklink h2 h3 blockquote quickimage quicktable',
    //    //plugins: [
    //    //    'advlist autolink lists link image charmap print preview anchor', 
    //    //    'searchreplace visualblocks code fullscreen',
    //    //    'insertdatetime media table paste code help wordcount',
    //    //    'emoticons hr pagebreak nonbreaking',
    //    //    'charmap quickbars save autoresize'
    //    //], 
    //    //toolbar: `undo redo | fontselect fontsizeselect formatselect | bold italic underline strikethrough backcolor |
    //    //        alignleft aligncenter alignright alignjustify | bullist numlist outdent indent checklist |
    //    //        forecolor backcolor casechange permanentpen formatpainter removeformat | link image media | code fullscreen`,

    //    height: 500,
    //    plugins: 'paste fullscreen',
    //    paste_as_text: false,
    //    //paste_webkit_styles: 'color font-weight font-style', // Only retain these styles
    //    //paste_retain_style_properties: 'color font-weight font-style',
    //    //valid_elements: 'p,strong,em,br',
    //   // forced_root_block: 'p',
    //    //forced_root_block: "",
    //    setup: function (editor) {
    //        editor.on('change', function () {
    //            tinymce.triggerSave();
    //            //validateRequiredfldTM();
    //        });
    //        editor.on('init', function () {

                
    //            // Ensure SutonnyMJ is the default font when the editor is initialized
    //            //editor.getBody().style.fontFamily = 'SutonnyMJ';

    //            $.ajax({
    //                url: '../fonts/fontname.txt', // Path to the text file
    //                method: 'GET',
    //                success: function (response) {
    //                    // Get the first line of the text file
    //                    var fontName = response.split('\n')[0].trim(); // Split by new line and get the first line
    //                    console.log(editor.settings.font_formats);
    //                    editor.getBody().style.fontFamily = fontName;
    //                    editor.settings.font_formats = fontName + "=" + fontName + ";SutonnyMJ=SutonnyMJ;AdarshaLipiNormal=AdarshaLipiNormal;Kalpurush=Kalpurush;SutonnyEMJ=SutonnyEMJ;SulekhaT=SulekhaT;  Andale Mono=andale mono,times; Arial=arial,helvetica,sans-serif; Arial Black=arial black,avant garde; Book Antiqua=book antiqua,palatino; Comic Sans MS=comic sans ms,sans-serif; Courier New=courier new,courier; Georgia=georgia,palatino; Helvetica=helvetica; Impact=impact,chicago; Symbol=symbol; Tahoma=tahoma,arial,helvetica,sans-serif; Terminal=terminal,monaco; Times New Roman=times new roman,times; Trebuchet MS=trebuchet ms,geneva; Verdana=verdana,geneva; Webdings=webdings; Wingdings=wingdings,zapf dingbats" ;

    //                    console.log(editor.settings.font_formats);
    //                },
    //                error: function () {
    //                    console.error('Error loading font from file.');
    //                }
    //            });
    //        });
    //        editor.on('paste', function (e) {
    //            let pastedData = e.clipboardData.getData('text'); // Get the plain text from the clipboard
    //            console.log(pastedData)
    //            var t = "bijoy";
    //            //var w = pastedData;
    //            var content1 = pastedData;//$('#hdneventdescription').val();
    //            console.log(content1)
    //            var str = content1.replace(/^\<p\>/, "").replace(/\<\/p\>$/, "");
    //            //w = cM(t, w);
    //            content1 = cM(t, str);

    //            //content1 = cleanText(content1);
    //            var wrappedContent = content1.split('\n').map(function (line) {
    //                return '<p>' + line + '</p>';  // Wrap each line in <p> tags
    //            }).join('');  // Join lines back together as HTML

    //            if (wrappedContent) {
    //                wrappedContent = wrappedContent.replace(/<p>&nbsp;<\/p>/g, '');
    //            }
    //            let cleanedText = wrappedContent.replace(/<p><br data-mce-bogus="1"><\/p>/g, '');

    //            var cleanedContent = wrappedContent.replace(/<p>&nbsp;<\/p>/g, '');
    //            console.log(cleanedContent)
    //            e.preventDefault(); // Prevent the default paste behavior
    //            cleanedContent = cleanedContent.replace(/<p><br data-mce-bogus="1"><\/p>/g, '');
    //            editor.insertContent(cleanedContent); // Insert modified content into the editor
    //        });

    //        // Automatically remove <p>&nbsp;</p> when the content is modified or set
    //        //editor.on('SetContent', function () {
    //        //    var content = editor.getContent();  // Get the current content
    //        //    var cleanedContent = content.replace(/<p>&nbsp;<\/p>/g, '');  // Remove all <p>&nbsp;</p>
    //        //    editor.setContent(cleanedContent);  // Set the cleaned content back into the editor
    //        //});
    //    }
    //});
});

function cleanText(text) {
    // Remove all <p><br data-mce-bogus="1"></p> occurrences
    let cleanedText = text.replace(/<p><br data-mce-bogus="1"><\/p>/g, '');

    // You can also add any additional text cleaning here if needed (e.g., empty lines)
    cleanedText = cleanedText.replace(/\n\s*\n/g, '\n');  // Remove extra empty lines
    cleanedText = cleanedText.replace(/^\s+|\s+$/g, '');  // Trim spaces at the start and end
    cleanedText = cleanedText.replace(/\s+/g, ' ');  // Replace multiple spaces with a single space

    return cleanedText;
}


// Function to remove all <p>&nbsp;</p> elements
function removeEmptyParagraphs(content) {
    // Use DOMParser to safely manipulate the HTML
    var parser = new DOMParser();
    var doc = parser.parseFromString(content, 'text/html');  // Parse the content as HTML
    var paragraphs = doc.querySelectorAll('p');  // Select all <p> elements

    paragraphs.forEach(function (p) {
        // Remove <p>&nbsp;</p> or any <p> with non-breaking space only
        if (p.innerHTML === '&nbsp;' || p.innerHTML.trim() === '') {
            p.remove();
        }
    });

    return doc.body.innerHTML;  // Return the cleaned HTML content
}