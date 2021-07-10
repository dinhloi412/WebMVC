/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.syntaxhightlight_lang = 'cshap';
	config.syntaxhightlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowseUrl ='/Areas/Admin/assets/admin/js1/Plugins/ckfinder.html';
	config.filebrowserImageBrowseUrl ='/Areas/Admin/assets/admin/js1/Plugins/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl ='/Areas/Admin/assets/admin/js1/Plugins/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl ='/Areas/Admin/assets/admin/js1/Plugins/core/connector/aspx/connector.aspx? command = QuickUpload & Type=File';
	config.filebrowserImageUploadUrl = '/Anh';
	config.filebrowserFlashUploadUrl ='/Areas/Admin/assets/admin/js1/Plugins/core/connector/aspx/connector.aspx? command = QuickUpload & Type=Flash';
	CKFinder.setupCKEditor(null,'/Areas/Admin/assets/admin/js1/Plugins');
};

