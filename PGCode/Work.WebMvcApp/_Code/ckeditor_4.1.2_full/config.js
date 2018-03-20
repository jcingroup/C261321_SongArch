/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    config.uiColor = '#AFD6FF';
    config.language = 'zh';
    config.enterMode = CKEDITOR.ENTER_P;
    config.stylesSet=
    [
     { name: '大標題', element: 'h4' },
     { name: '小標題', element: 'h5' },
     { name: '段落', element: 'p' }
    ];
    
    config.contentsCss = ['../../Content/css/editor.css'];

    config.toolbar = [{
        name: "basicstyles",
        items: ["FontSize", "Bold", "Italic", "-", "JustifyLeft", "JustifyCenter", "JustifyRight"]
    }, {
        name: "paragraph",
        items: ["NumberedList", "BulletedList", "-"]
    }, {
        name: "tools",
        items: ["Maximize", "-", "Image", "Table"]
    }, {
        name: "styles",
        items: ["Styles", "Format"]
    }, {
        name: "links",
        items: ["Link", "Unlink", "Anchor"]
    }, {
        name: "colors",
        items: ["TextColor", "BGColor"]
    }, { name: "editing" }, {
        name: "document",
        items: ["Source", "-", "DocProps"]
    }, {
        name: "clipboard",
        items: ["Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "Undo", "Redo"]
    }];
};
